using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Logging;

namespace OnlinePayments.Sdk.DefaultImpl
{
    /// <summary>
    /// The default implementation for the connection interface. Supports Pooling, and is thread safe.
    /// </summary>
    public class DefaultConnection : IPooledConnection
    {
        private readonly TimeSpan DEFAULT_SOCKET_TIMEOUT = TimeSpan.FromSeconds(10);

        public DefaultConnection(TimeSpan? socketTimeout = null, int maxConnections = 10, Proxy proxy = null)
        {
            var handler = new HttpClientHandler();
            if (proxy != null)
            {
                handler.Proxy = new WebProxy(proxy.Uri);
                if (proxy.Username != null)
                {
                    handler.Proxy.Credentials = new NetworkCredential(proxy.Username, proxy.Password);
                }

                handler.UseProxy = true;
            }

            ServicePointManager.DefaultConnectionLimit = maxConnections;
            _httpClient = new HttpClient(handler)
            {
                Timeout = socketTimeout != null ? socketTimeout.Value : DEFAULT_SOCKET_TIMEOUT
            };
        }

        internal DefaultConnection(ProxyConfiguration proxyConfig, TimeSpan? socketTimeout = null, int maxConnections = 10)
        {
            var handler = new HttpClientHandler();
            if (proxyConfig != null)
            {
                handler.Proxy = new WebProxy(proxyConfig.Uri);
                if (proxyConfig.Username != null)
                {
                    handler.Proxy.Credentials = new NetworkCredential(proxyConfig.Username, proxyConfig.Password);
                }

                handler.UseProxy = true;
            }

            ServicePointManager.DefaultConnectionLimit = maxConnections;
            _httpClient = new HttpClient(handler)
            {
                Timeout = socketTimeout != null ? socketTimeout.Value : DEFAULT_SOCKET_TIMEOUT
            };
        }

        async Task<R> SendHttpMessage<R>(HttpMethod method, Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R>responseHandler, string body = null)
        {
            var content = (body == null ? null : new StringContent(body));
            return await SendHttpMessage<R>(method, uri, requestHeaders, responseHandler, content, body)
                .ConfigureAwait(false);
        }

        async Task<R> SendHttpMessage<R>(HttpMethod method, Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R> responseHandler, HttpContent content, string contentString)
        {
            var guid = Guid.NewGuid();
            try
            {
                using (var message = new HttpRequestMessage(method, uri))
                {
                    if (content != null)
                    {
                        message.Content = content;
                    }
                    foreach (var a in requestHeaders)
                    {
                        if (a is EntityHeader)
                        {
                            if (content != null)
                            {
                                message.Content.Headers.Remove(a.Name);
                                message.Content.Headers.Add(a.Name, a.Value);
                            }
                        }
                        else
                        {
                            message.Headers.Add(a.Name, a.Value);
                        }
                    }
                    var startTime = DateTime.Now;
                    LogRequest(guid, message, content, contentString);
                    var httpResponseTask = _httpClient.SendAsync(message)
                        .ConfigureAwait(false);

                    using (var httpResponse = await httpResponseTask)
                    {
                        var responseBodyTask = httpResponse?.Content?.ReadAsStreamAsync() ?? Task.FromResult<Stream>(new MemoryStream());
                        var headers = from header in httpResponse.Headers
                                      from value in header.Value
                                      select new ResponseHeader(header.Key, value);

                        var responseBody = await responseBodyTask
                            .ConfigureAwait(false);
                        var duration = DateTime.Now - startTime;
                        responseBody = LogResponse(guid, httpResponse, httpResponse.Content.Headers, responseBody, duration);
                        var responseBodyHeaders = from header in httpResponse.Content.Headers
                                                  from aValue in header.Value
                                                  select new EntityHeader(header.Key, aValue);
                        return responseHandler(httpResponse.StatusCode, responseBody, headers.Cast<IResponseHeader>().Union(responseBodyHeaders));
                    }
                }
            }
            catch (HttpRequestException exception)
            {
                LogException(guid, exception);
                throw new CommunicationException(exception);
            }
            catch (TaskCanceledException exception)
            {
                LogException(guid, exception);
                throw new CommunicationException(exception);
            }
            catch (WebException exception)
            {
                LogException(guid, exception);
                throw new CommunicationException(exception);
            }
            catch (CommunicationException exception)
            {
                LogException(guid, exception);
                throw exception;
            }
        }

        #region IPooledConnection implementation
        public void CloseIdleConnections(TimeSpan timespan)
        {
            // Done automatically so this is a No-Op
        }

        public void CloseExpiredConnections()
        {
            // Done automatically so this is a No-Op
        }
        #endregion

        #region IConnection implementation
        /// <inheritdoc/>
        public async Task<R> Get<R>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R> responseHandler)
        {
            return await SendHttpMessage<R>(HttpMethod.Get, uri, requestHeaders,  responseHandler)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<R> Delete<R>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R> responseHandler)
        {
            return await SendHttpMessage<R>(HttpMethod.Delete, uri, requestHeaders,  responseHandler)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<R> Post<R>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, string body, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R> responseHandler)
        {
            return await SendHttpMessage<R>(HttpMethod.Post, uri, requestHeaders, responseHandler, body)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<R> Put<R>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, string body, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R> responseHandler)
        {
            return await SendHttpMessage<R>(HttpMethod.Put, uri, requestHeaders,  responseHandler, body)
                .ConfigureAwait(false);
        }
        #endregion

        #region ILoggingCapable implementation
        public void EnableLogging(ICommunicatorLogger communicatorLogger)
        {
            _communicatorLogger = communicatorLogger;
        }

        public void DisableLogging()
        {
            _communicatorLogger = null;
        }
        #endregion

        #region IDisposable implementation
        public void Dispose()
        {
            _httpClient.Dispose();
        }
        #endregion

        #region Logging
        void LogRequest(Guid guid, HttpRequestMessage message, HttpContent body, string bodyContent)
        {
            var logger = _communicatorLogger;
            if (logger == null)
            {
                return;
            }

            var sb = new RequestLogMessageBuilder(guid.ToString(), message.Method.ToString(), message.RequestUri.PathAndQuery);
            foreach (var header in message.Headers)
            {
                sb.AddHeader(header.Key, string.Join(" ", header.Value));
            }
            if (bodyContent != null && body != null)
            {
                foreach (var header in body.Headers)
                {
                    sb.AddHeader(header.Key, string.Join(" ", header.Value));
                }
                sb.SetBody(bodyContent, body.Headers?.ContentType.ToString());
            }
            logger.Log(sb.Message);
        }

        Stream LogResponse(Guid guid, HttpResponseMessage httpResponse, HttpContentHeaders responseBodyHeaders, Stream responseBodyStream, TimeSpan duration)
        {
            var logger = _communicatorLogger;
            if (logger == null)
            {
                return responseBodyStream;
            }

            var sb = new ResponseLogMessageBuilder(guid.ToString(), httpResponse.StatusCode)
            {
                Duration = duration
            };
            foreach (var header in httpResponse.Headers)
            {
                sb.AddHeader(header.Key, string.Join(" ", header.Value));
            }
            if (responseBodyHeaders != null)
            {
                foreach (var header in responseBodyHeaders)
                {
                    sb.AddHeader(header.Key, string.Join(" ", header.Value));
                }
            }

            var contentType = responseBodyHeaders?.ContentType?.ToString();

            var sr = new StreamReader(responseBodyStream);
            string responseBody = sr.ReadToEnd();
            if (!string.IsNullOrEmpty(responseBody))
            {
                sb.SetBody(responseBody, contentType);
            }
            logger.Log(sb.Message);
            if (responseBodyStream.CanSeek)
            {
                responseBodyStream.Seek(0, SeekOrigin.Begin);
                return responseBodyStream;
            }
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(responseBody);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        void LogException(Guid guid, Exception exception)
        {
            _communicatorLogger?.Log("Error occurred for outgoing request (requestId='" + guid + "')", exception);
        }
        #endregion

        // Private because not all operations are guaranteed to be thread safe.
        // This class only uses thread safe methods (except in the constructor)
        readonly HttpClient _httpClient;

        ICommunicatorLogger _communicatorLogger;
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Logging;

namespace OnlinePayments.Sdk.Communication
{
    /// <summary>
    /// The default implementation for the connection interface. Supports Pooling, and is thread safe.
    /// </summary>
    public class DefaultConnection : IPooledConnection
    {
        public DefaultConnection(TimeSpan? socketTimeout, int maxConnections = 2, Proxy proxy = null, HttpClientHandler httpClientHandler = null)
        {
            var handler = httpClientHandler ?? new HttpClientHandler();
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
            var httpClient = new HttpClient(handler);
            if (socketTimeout != null)
            {
                httpClient.Timeout = socketTimeout.Value;
            }

            // Always return the same HttpClient instance. Don't close it after each request but only when Dispose() is called
            _httpClientProvider = () => httpClient;
            _postRequestAction = client => { };
            _disposeAction = httpClient.Dispose;
        }

        /// <summary>
        /// Creates a new <c>DefaultConnection</c> with a custom provider for <see cref="HttpClient"/> instances to use for each request.
        /// This could be based on <c>IHttpClientFactor</c> or something completely different.
        /// <p>This constructor will dispose provided <c>HttpClient</c> instances after each request.</p>
        /// </summary>
        /// <param name="httpClientProvider">The custom provider for <c>HttpClient</c> instances</param>
        /// <param name="disposeAction">An optional action to call from the <c>Dispose</c> method</param>
        /// <seealso cref="DefaultConnection(Func{HttpClient}, Action{HttpClient}, Action)"/>
        public DefaultConnection(Func<HttpClient> httpClientProvider, Action disposeAction = null)
            : this(httpClientProvider, client => client.Dispose(), disposeAction)
        {

        }

        /// <summary>
        /// Creates a new <c>DefaultConnection</c> with a custom provider for <see cref="HttpClient"/> instances to use for each request.
        /// This could be based on <c>IHttpClientFactor</c> or something completely different.
        /// </summary>
        /// <param name="httpClientProvider">The custom provider for <c>HttpClient</c> instances</param>
        /// <param name="postRequestAction">A mandatory action to call after each request, e.g. to dispose provided <c>HttpClient</c> instances</param>
        /// <param name="disposeAction">An optional action to call from the <c>Dispose</c> method</param>
        public DefaultConnection(Func<HttpClient> httpClientProvider, Action<HttpClient> postRequestAction, Action disposeAction = null)
        {
            _httpClientProvider = httpClientProvider ?? throw new ArgumentException("httpClientProvider is required");
            _postRequestAction = postRequestAction ?? throw new ArgumentException("postRequestAction is required");
            _disposeAction = disposeAction ?? (() => { });
        }

        private async Task<T> SendHttpMessage<T>(HttpMethod method, Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T>responseHandler, string body = null)
        {
            var content = body == null ? null : new StringContent(body);
            return await SendHttpMessage(method, uri, requestHeaders, responseHandler, content, body).ConfigureAwait(false);
        }

        private async Task<T> SendHttpMessage<T>(HttpMethod method, Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T> responseHandler, MultipartFormDataObject multipart)
        {
            var content = new MultipartFormDataContent(multipart.Boundary);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(multipart.ContentType);
            foreach (var value in multipart.Values)
            {
                var valueContent = new StringContent(value.Value, System.Text.Encoding.UTF8);
                content.Add(valueContent, value.Key);
            }
            foreach (var file in multipart.Files)
            {
                var fileContent = new StreamContent(file.Value.Content);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.Value.ContentType);
                if (file.Value.ContentLength >= 0)
                {
                    fileContent.Headers.ContentLength = file.Value.ContentLength;
                }
                content.Add(fileContent, file.Key, file.Value.FileName);
            }

            var contentType = content.Headers.ContentType;
            if (contentType == null || !multipart.ContentType.Equals(contentType.ToString()))
            {
                throw new InvalidOperationException("MultipartFormDataContent did not create the expected content type" + contentType);
            }

            return await SendHttpMessage(method, uri, requestHeaders, responseHandler, content, "<binary content>").ConfigureAwait(false);
        }

        private async Task<T> SendHttpMessage<T>(HttpMethod method, Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T> responseHandler, HttpContent content, string contentString)
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

                    var httpClient = _httpClientProvider();
                    try
                    {
                        using (var httpResponse = await httpClient.SendAsync(message).ConfigureAwait(false))
                        {
                            var headers = from header in httpResponse.Headers
                                          from value in header.Value
                                          select new ResponseHeader(header.Key, value);

                            var responseBodyTask = httpResponse.Content?.ReadAsStreamAsync() ?? Task.FromResult<Stream>(new MemoryStream());
                            var responseBody = await responseBodyTask.ConfigureAwait(false);

                            var endTime = DateTime.Now;
                            var duration = endTime - startTime;

                            responseBody = LogResponse(guid, httpResponse, httpResponse.Content?.Headers, responseBody, duration);

                            var responseBodyHeaders = from header in httpResponse.Content?.Headers
                                                      from value in header.Value
                                                      select new EntityHeader(header.Key, value);

                            return responseHandler(httpResponse.StatusCode, responseBody, headers.Cast<IResponseHeader>().Union(responseBodyHeaders));
                        }
                    }
                    finally
                    {
                        _postRequestAction(httpClient);
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
                throw;
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
        public async Task<T> Get<T>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T> responseHandler)
        {
            return await SendHttpMessage(HttpMethod.Get, uri, requestHeaders,  responseHandler).ConfigureAwait(false);
        }

        public async Task<T> Delete<T>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T> responseHandler)
        {
            return await SendHttpMessage(HttpMethod.Delete, uri, requestHeaders,  responseHandler).ConfigureAwait(false);
        }

        public async Task<T> Post<T>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, string body, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T> responseHandler)
        {
            return await SendHttpMessage(HttpMethod.Post, uri, requestHeaders, responseHandler, body).ConfigureAwait(false);
        }

        public async Task<T> Post<T>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, MultipartFormDataObject multipart, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T> responseHandler)
        {
            return await SendHttpMessage(HttpMethod.Post, uri, requestHeaders, responseHandler, multipart).ConfigureAwait(false);
        }

        public async Task<T> Put<T>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, string body, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T> responseHandler)
        {
            return await SendHttpMessage(HttpMethod.Put, uri, requestHeaders,  responseHandler, body).ConfigureAwait(false);
        }

        public async Task<T> Put<T>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, MultipartFormDataObject multipart, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, T> responseHandler)
        {
            return await SendHttpMessage(HttpMethod.Put, uri, requestHeaders, responseHandler, multipart).ConfigureAwait(false);
        }
        #endregion

        #region IObfuscationCapable implementation
        public BodyObfuscator BodyObfuscator
        {
            set => _bodyObfuscator = value ?? throw new ArgumentException("bodyObfuscator is required");
        }

        public HeaderObfuscator HeaderObfuscator
        {
            set => _headerObfuscator = value ?? throw new ArgumentException("headerObfuscator is required");
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
            _disposeAction();
        }
        #endregion

        #region Logging
        private void LogRequest(Guid guid, HttpRequestMessage message, HttpContent body, string bodyContent)
        {
            var logger = _communicatorLogger;
            if (logger == null)
            {
                return;
            }

            var sb = new RequestLogMessageBuilder(guid.ToString(), message.Method.ToString(), message.RequestUri.PathAndQuery, _bodyObfuscator, _headerObfuscator);
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

        private Stream LogResponse(Guid guid, HttpResponseMessage httpResponse, HttpContentHeaders responseBodyHeaders, Stream responseBodyStream, TimeSpan duration)
        {
            var logger = _communicatorLogger;
            if (logger == null)
            {
                return responseBodyStream;
            }

            var sb = new ResponseLogMessageBuilder(guid.ToString(), httpResponse.StatusCode, duration, _bodyObfuscator, _headerObfuscator);
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
            if (IsBinaryContent(contentType))
            {
                sb.SetBinaryContentBody(contentType);
                logger.Log(sb.Message);
                return responseBodyStream;
            }

            var sr = new StreamReader(responseBodyStream);
            var responseBody = sr.ReadToEnd();
            if (!string.IsNullOrEmpty(responseBody))
            {
                sb.SetBody(responseBody, contentType);
            }
            logger.Log(sb.Message);
            if (responseBodyStream.CanSeek) {
                responseBodyStream.Seek(0, SeekOrigin.Begin);
                return responseBodyStream;
            }
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(responseBody);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private void LogException(Guid guid, Exception exception)
        {
            _communicatorLogger?.Log("Error occurred for outgoing request (requestId='" + guid + "')", exception);
        }

        private static bool IsBinaryContent(string contentType)
        {
            return contentType != null
                && !contentType.StartsWith("text/", StringComparison.OrdinalIgnoreCase)
                               && contentType.IndexOf("json", StringComparison.OrdinalIgnoreCase) < 0
                               && contentType.IndexOf("xml", StringComparison.OrdinalIgnoreCase) < 0;
        }
        #endregion

        private readonly Func<HttpClient> _httpClientProvider;
        private readonly Action<HttpClient> _postRequestAction;
        private readonly Action _disposeAction;

        private BodyObfuscator _bodyObfuscator = BodyObfuscator.DefaultObfuscator;
        private HeaderObfuscator _headerObfuscator = HeaderObfuscator.DefaultObfuscator;

        private ICommunicatorLogger _communicatorLogger;
    }
}

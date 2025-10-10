using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Authentication;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;
using OnlinePayments.Sdk.Logging;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Used to communicate with the Online Payments platform web services.
    /// </summary>
    /// <remarks>
    /// It contains all the logic to transform a request object to a HTTP request and a HTTP response to a response object.
    /// It is also thread safe.
    /// </remarks>
    public class Communicator : ICommunicator
    {
        /// <inheritdoc cref="ICommunicator"/>
        public IMarshaller Marshaller { get; }

        public Communicator(Uri apiEndpoint, IConnection connection, IAuthenticator authenticator, IMetadataProvider metadataProvider, IMarshaller marshaller)
        {
            if (apiEndpoint == null)
            {
                throw new ArgumentException("apiEndpoint is required");
            }
            if (apiEndpoint.HasPath())
            {
                throw new ArgumentException("apiEndpoint should not contain a path");
            }
            if (apiEndpoint.HasUserInfoOrQueryOrFragment())
            {
                throw new ArgumentException("apiEndpoint should not contain user info, query or fragment");
            }
            ApiEndpoint = apiEndpoint;
            Connection = connection ?? throw new ArgumentException("connection is required");
            Authenticator = authenticator ?? throw new ArgumentException("authenticator is required");
            MetadataProvider = metadataProvider ?? throw new ArgumentException("metadataProvider is required");
            Marshaller = marshaller ?? throw new ArgumentException("marshaller is required");
        }

        #region IDisposable implementation
        /// <summary>
        /// Releases all resource used by the <see cref="T:OnlinePayments.Sdk.Communicator"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="T:OnlinePayments.Sdk.Communicator"/>. The <see cref="Dispose"/> method leaves the
        /// <see cref="T:OnlinePayments.Sdk.Communicator"/> in an unusable state. After calling <see cref="Dispose"/>,
        /// you must release all references to the <see cref="T:OnlinePayments.Sdk.Communicator"/> so the garbage
        /// collector can reclaim the memory that the <see cref="T:OnlinePayments.Sdk.Communicator"/> was occupying.</remarks>
        public void Dispose()
        {
            Connection.Dispose();
        }
        #endregion

        #region IObfuscationCapable implementation
        public BodyObfuscator BodyObfuscator
        {
            set => Connection.BodyObfuscator = value;
        }

        public HeaderObfuscator HeaderObfuscator
        {
            set => Connection.HeaderObfuscator = value;
        }
        #endregion

        #region ILoggingCapable implementation
        public void EnableLogging(ICommunicatorLogger communicatorLogger)
        {
            Connection.EnableLogging(communicatorLogger);
        }

        public void DisableLogging()
        {
            Connection.DisableLogging();
        }
        #endregion

        #region HTTP methods
        /// <inheritdoc cref="ICommunicator"/>
        public async Task<T> Get<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                    CallContext context)
        {
            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();
            requestHeaders = await AddGenericHeaders(HttpMethod.Get, uri, requestHeaders, context).ConfigureAwait(false);
            return await Connection.Get(uri, requestHeaders, (status, body, headers) =>
                ProcessResponse<T>(status, body, headers, relativePath, context)
            ).ConfigureAwait(false);
        }

        /// <inheritdoc cref="ICommunicator"/>
        public async Task Get(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                              Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context)
        {
            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();
            requestHeaders = await AddGenericHeaders(HttpMethod.Get, uri, requestHeaders, context).ConfigureAwait(false);
            await Connection.Get(uri, requestHeaders, (status, body, headers) =>
                ProcessResponse<object>(status, body, headers, relativePath, context, bodyHandler)
            ).ConfigureAwait(false);
        }

        /// <inheritdoc cref="ICommunicator"/>
        public async Task<T> Delete<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                       CallContext context)
        {
            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();
            requestHeaders = await AddGenericHeaders(HttpMethod.Delete, uri, requestHeaders, context).ConfigureAwait(false);
            return await Connection.Delete(uri, requestHeaders, (status, body, headers) =>
                ProcessResponse<T>(status, body, headers, relativePath, context)
            ).ConfigureAwait(false);
        }

        /// <inheritdoc cref="ICommunicator"/>
        public async Task Delete(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                 Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context)
        {
            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();
            requestHeaders = await AddGenericHeaders(HttpMethod.Delete, uri, requestHeaders, context).ConfigureAwait(false);
            await Connection.Delete(uri, requestHeaders, (status, body, headers) =>
                ProcessResponse<object>(status, body, headers, relativePath, context, bodyHandler)
            ).ConfigureAwait(false);
        }

        /// <inheritdoc cref="ICommunicator"/>
        public async Task<T> Post<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                     object requestBody, CallContext context)
        {
            switch (requestBody)
            {
                case MultipartFormDataObject multipartFormDataObject:
                    return await Post<T>(relativePath, requestHeaders, requestParameters, multipartFormDataObject, context).ConfigureAwait(false);
                case IMultipartFormDataRequest multipartFormDataRequest:
                {
                    var multipart = multipartFormDataRequest.ToMultipartFormDataObject();
                    return await Post<T>(relativePath, requestHeaders, requestParameters, multipart, context).ConfigureAwait(false);
                }
            }

            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();

            string requestJson = null;
            var requestHeaderList = requestHeaders.ToList();
            if (requestBody != null)
            {
                requestHeaderList.Add(new EntityHeader("Content-Type", "application/json"));
                requestJson = Marshaller.Marshal(requestBody);
            }

            requestHeaders = await AddGenericHeaders(HttpMethod.Post, uri, requestHeaderList, context).ConfigureAwait(false);
            return await Connection.Post(uri, requestHeaders, requestJson, (status, body, headers) =>
                ProcessResponse<T>(status, body, headers, relativePath, context)
            ).ConfigureAwait(false);
        }

        private async Task<T> Post<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                      MultipartFormDataObject multipart, CallContext context)
        {
            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();

            var requestHeaderList = requestHeaders.ToList();
            requestHeaderList.Add(new EntityHeader("Content-Type", multipart.ContentType));

            requestHeaders = await AddGenericHeaders(HttpMethod.Post, uri, requestHeaderList, context).ConfigureAwait(false);
            return await Connection.Post(uri, requestHeaders, multipart, (status, body, headers) =>
                ProcessResponse<T>(status, body, headers, relativePath, context)
            ).ConfigureAwait(false);
        }

        /// <inheritdoc cref="ICommunicator"/>
        public async Task Post(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                               object requestBody, Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context)
        {
            switch (requestBody)
            {
                case MultipartFormDataObject multipartFormDataObject:
                    await Post(relativePath, requestHeaders, requestParameters, multipartFormDataObject, bodyHandler, context).ConfigureAwait(false);
                    return;
                case IMultipartFormDataRequest multipartFormDataRequest:
                {
                    var multipart = multipartFormDataRequest.ToMultipartFormDataObject();
                    await Post(relativePath, requestHeaders, requestParameters, multipart, bodyHandler, context).ConfigureAwait(false);
                    return;
                }
            }

            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();

            string requestJson = null;
            var requestHeaderList = requestHeaders.ToList();
            if (requestBody != null)
            {
                requestHeaderList.Add(new EntityHeader("Content-Type", "application/json"));
                requestJson = Marshaller.Marshal(requestBody);
            }

            requestHeaders = await AddGenericHeaders(HttpMethod.Post, uri, requestHeaderList, context).ConfigureAwait(false);
            await Connection.Post(uri, requestHeaders, requestJson, (status, body, headers) =>
                ProcessResponse<object>(status, body, headers, relativePath, context, bodyHandler)
            ).ConfigureAwait(false);
        }

        private async Task Post(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                MultipartFormDataObject multipart, Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context)
        {
            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();

            var requestHeaderList = requestHeaders.ToList();
            requestHeaderList.Add(new EntityHeader("Content-Type", multipart.ContentType));

            requestHeaders = await AddGenericHeaders(HttpMethod.Post, uri, requestHeaderList, context).ConfigureAwait(false);
            await Connection.Post(uri, requestHeaders, multipart, (status, body, headers) =>
                ProcessResponse<object>(status, body, headers, relativePath, context, bodyHandler)
            ).ConfigureAwait(false);
        }

        /// <inheritdoc cref="ICommunicator"/>
        public async Task<T> Put<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                    object requestBody, CallContext context)
        {
            switch (requestBody)
            {
                case MultipartFormDataObject multipartFormDataObject:
                    return await Put<T>(relativePath, requestHeaders, requestParameters, multipartFormDataObject, context).ConfigureAwait(false);
                case IMultipartFormDataRequest multipartFormDataRequest:
                {
                    var multipart = multipartFormDataRequest.ToMultipartFormDataObject();
                    return await Put<T>(relativePath, requestHeaders, requestParameters, multipart, context).ConfigureAwait(false);
                }
            }

            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();

            string requestJson = null;
            var requestHeaderList = requestHeaders.ToList();
            if (requestBody != null)
            {
                requestHeaderList.Add(new EntityHeader("Content-Type", "application/json"));
                requestJson = Marshaller.Marshal(requestBody);
            }

            requestHeaders = await AddGenericHeaders(HttpMethod.Put, uri, requestHeaderList, context).ConfigureAwait(false);
            return await Connection.Put(uri, requestHeaders, requestJson, (status, body, headers) =>
                ProcessResponse<T>(status, body, headers, relativePath, context)
            ).ConfigureAwait(false);
        }

        private async Task<T> Put<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                     MultipartFormDataObject multipart, CallContext context)
        {
            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();

            var requestHeaderList = requestHeaders.ToList();
            requestHeaderList.Add(new EntityHeader("Content-Type", multipart.ContentType));

            requestHeaders = await AddGenericHeaders(HttpMethod.Put, uri, requestHeaderList, context).ConfigureAwait(false);
            return await Connection.Put(uri, requestHeaders, multipart, (status, body, headers) =>
                ProcessResponse<T>(status, body, headers, relativePath, context)
            ).ConfigureAwait(false);
        }

        /// <inheritdoc cref="ICommunicator"/>
        public async Task Put(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                              object requestBody, Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context)
        {
            switch (requestBody)
            {
                case MultipartFormDataObject multipartFormDataObject:
                    await Put(relativePath, requestHeaders, requestParameters, multipartFormDataObject, bodyHandler, context).ConfigureAwait(false);
                    return;
                case IMultipartFormDataRequest multipartFormDataRequest:
                {
                    var multipart = multipartFormDataRequest.ToMultipartFormDataObject();
                    await Put(relativePath, requestHeaders, requestParameters, multipart, bodyHandler, context).ConfigureAwait(false);
                    return;
                }
            }

            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();

            string requestJson = null;
            var requestHeaderList = requestHeaders.ToList();
            if (requestBody != null)
            {
                requestHeaderList.Add(new EntityHeader("Content-Type", "application/json"));
                requestJson = Marshaller.Marshal(requestBody);
            }

            requestHeaders = await AddGenericHeaders(HttpMethod.Put, uri, requestHeaderList, context).ConfigureAwait(false);
            await Connection.Put(uri, requestHeaders, requestJson, (status, body, headers) =>
                ProcessResponse<object>(status, body, headers, relativePath, context, bodyHandler)
            ).ConfigureAwait(false);
        }

        private async Task Put(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                               MultipartFormDataObject multipart, Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context)
        {
            var requestParameterList = requestParameters?.ToRequestParameters();
            var uri = ToAbsoluteUri(relativePath, requestParameterList);
            requestHeaders = requestHeaders ?? new List<IRequestHeader>();

            var requestHeaderList = requestHeaders.ToList();
            requestHeaderList.Add(new EntityHeader("Content-Type", multipart.ContentType));

            requestHeaders = await AddGenericHeaders(HttpMethod.Put, uri, requestHeaderList, context).ConfigureAwait(false);
            await Connection.Put(uri, requestHeaders, multipart, (status, body, headers) =>
                ProcessResponse<object>(status, body, headers, relativePath, context, bodyHandler)
            ).ConfigureAwait(false);
        }
        #endregion

        /// <inheritdoc cref="ICommunicator"/>
        public void CloseExpiredConnections()
        {
            if (Connection is IPooledConnection pooledConnection)
            {
                pooledConnection.CloseExpiredConnections();
            }
        }

        /// <inheritdoc cref="ICommunicator"/>
        public void CloseIdleConnections(TimeSpan timespan)
        {
            if (Connection is IPooledConnection pooledConnection)
            {
                pooledConnection.CloseIdleConnections(timespan);
            }
        }

        internal Uri ApiEndpoint { get; }

        internal IConnection Connection { get; }

        internal IMetadataProvider MetadataProvider { get; }

        internal IAuthenticator Authenticator { get; }

        internal Uri ToAbsoluteUri(string relativePath, IEnumerable<RequestParam> requestParameters)
        {
            string absolutePath;
            if (relativePath.StartsWith("/", StringComparison.Ordinal))
            {
                absolutePath = relativePath;
            }
            else
            {
                absolutePath = "/" + relativePath;
            }

            var uriBuilder = new UriBuilder
            {
                Scheme = ApiEndpoint.Scheme,
                Host = ApiEndpoint.Host,
                Port = ApiEndpoint.Port,
                Path = absolutePath
            };

            if (requestParameters != null)
            {
                foreach (var nvp in requestParameters)
                {
                    uriBuilder.AddParameter(nvp.Name, nvp.Value);
                }
            }

            return uriBuilder.Uri;
        }

        /// <summary>
        /// Adds the necessary headers to the given list of headers. This includes the authorization header,
        /// which uses other headers, so when you need to override this method,
        /// make sure to call <c>base.AddGenericHeaders</c> at the <i>end</i> of your overridden method.
        /// </summary>
        protected async Task<IEnumerable<IRequestHeader>> AddGenericHeaders(HttpMethod httpMethod, Uri uri, IEnumerable<IRequestHeader> requestHeaders, CallContext context)
        {
            var requestHeaderList = requestHeaders.ToList();

            // add server meta info headers
            requestHeaderList.AddRange(MetadataProvider.ServerMetadataHeaders);

            // add date header
            requestHeaderList.Add(new RequestHeader("Date", GetHeaderDateString()));

            // add context specific headers
            if (context?.IdempotenceKey != null)
            {
                requestHeaderList.Add(new RequestHeader("X-GCS-Idempotence-Key", context.IdempotenceKey));
            }

            // add authorization
            var authorization = await Authenticator.GetAuthorization(httpMethod, uri, requestHeaderList);
            requestHeaderList.Add(new RequestHeader("Authorization", authorization));
            return requestHeaderList;
        }

        /// <summary>
        /// Gets the date in the preferred format for the HTTP date header (RFC1123).
        /// </summary>
        /// <returns>The header date string.</returns>
        protected static string GetHeaderDateString()
        {
            return DateTime.UtcNow.ToString("r");
        }

        /// <summary>
        /// Checks the response for errors and throws an exception if necessary.
        /// </summary>
        protected static void ThrowExceptionIfNecessary(HttpStatusCode statusCode, Stream stream, IEnumerable<IResponseHeader> headers, string requestPath)
        {
            var intStatusCode = (int)statusCode;
            // status codes in the 100 or 300 range are not expected
            if (intStatusCode < 200 || intStatusCode >= 300)
            {
                var sr = new StreamReader(stream);
                var body = sr.ReadToEnd();

                if (string.IsNullOrEmpty(body) || !IsJson(headers))
                {
                    var cause = new ResponseException(statusCode, body, headers);
                    if (intStatusCode == (int)HttpStatusCode.NotFound)
                    {
                        throw new NotFoundException("The requested resource was not found; invalid path: " + requestPath, cause);
                    }
                    throw new CommunicationException(cause);
                }
                throw new ResponseException(statusCode, body, headers);
            }
        }

        protected T ProcessResponse<T>(HttpStatusCode statusCode, Stream stream, IEnumerable<IResponseHeader> headers, string requestPath, CallContext context, Action<Stream, IEnumerable<IResponseHeader>> bodyHandler = null)
        {
            if (context != null)
            {
                context.IdempotenceRequestTimestamp = GetIdempotenceTimestamp(headers);
                context.IdempotenceResponseDateTime = GetIdempotenceResponseDateTime(headers);
            }
            ThrowExceptionIfNecessary(statusCode, stream, headers, requestPath);
            if (bodyHandler == null) {
                return Marshaller.Unmarshal<T>(stream);
            }
            try
            {
                bodyHandler(stream, headers);
            }
            catch (Exception e)
            {
                throw new BodyHandlerException("The bodyhandler threw an exception", e);
            }
            return default;
        }

        protected static long? GetIdempotenceTimestamp(IEnumerable<IResponseHeader> headers)
        {
            if (long.TryParse(headers?.GetHeaderValue("X-GCS-Idempotence-Request-Timestamp"), out var retValue))
            {
                return retValue;
            }
            return null;
        }

        protected static DateTimeOffset? GetIdempotenceResponseDateTime(IEnumerable<IResponseHeader> headers)
        {
            if (DateTimeOffset.TryParse(headers?.GetHeaderValue("IdempotencyResponseDatetime"), out var retValue))
            {
                return retValue;
            }

            return null;
        }

        private static bool IsJson(IEnumerable<IResponseHeader> headers)
        {
            var contentType = headers?.GetHeaderValue("Content-Type")?.ToLower();
            return contentType == null
                   || "application/json".Equals(contentType) || contentType.StartsWith("application/json", StringComparison.Ordinal)
                   || "application/problem+json".Equals(contentType) || contentType.StartsWith("application/problem+json", StringComparison.Ordinal);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Logging;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Represents a connection to the payment platform server. Thread-safe.
    /// </summary>
    public interface IConnection : IDisposable, ILoggingCapable
    {
        /// <summary>
        /// Send a GET request to the payment platform.
        /// </summary>
        /// <param name="uri">The URI to call, including any necessary query parameters.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="responseHandler">A callback that handles the stream from the response</param>
        /// <returns>Returns the object that was returned from the callback</returns>
        /// <exception cref="CommunicationException">when an exception occurred communicating with the payment platform</exception>
        Task<R> Get<R>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R> responseHandler);

        /// <summary>
        /// Send a DELETE request to the payment platform.
        /// </summary>
        /// <param name="uri">The URI to call, including any necessary query parameters.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="responseHandler">A callback that handles the stream from the response</param>
        /// <returns>Returns the object that was returned from the callback</returns>
        /// <exception cref="CommunicationException">when an exception occurred communicating with the payment platform</exception>
        Task<R> Delete<R>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R> responseHandler);

        /// <summary>
        /// Send a POST request to the payment platform.
        /// </summary>
        /// <param name="uri">The URI to call, including any necessary query parameters.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="body">The optional body to send.</param>
        /// <param name="responseHandler">A callback that handles the stream from the response</param>
        /// <returns>Returns the object that was returned from the callback</returns>
        /// <exception cref="CommunicationException">when an exception occurred communicating with the payment platform</exception>
        Task<R> Post<R>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, string body, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R>  responseHandler);

        /// <summary>
        /// Send a PUT request to the payment platform.
        /// </summary>
        /// <param name="uri">The URI to call, including any necessary query parameters.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="responseHandler">A callback that handles the stream from the response</param>
        /// <returns>Returns the object that was returned from the callback</returns>
        /// <param name="body">The optional body to send.</param>
        /// <exception cref="CommunicationException">when an exception occurred communicating with the payment platform</exception>
        Task<R> Put<R>(Uri uri, IEnumerable<IRequestHeader> requestHeaders, string body, Func<HttpStatusCode, Stream, IEnumerable<IResponseHeader>, R>  responseHandler);
    }
}

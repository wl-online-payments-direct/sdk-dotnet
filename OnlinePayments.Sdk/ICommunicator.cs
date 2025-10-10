using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Json;
using OnlinePayments.Sdk.Logging;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// Used to communicate with the payment platform web services.
    /// </summary>
    /// <remarks>
    /// It contains all the logic to transform a request object to a HTTP request and a HTTP response to a response object.
    /// It is also thread safe.
    /// </remarks>
    public interface ICommunicator : IDisposable, ILoggingCapable, IObfuscationCapable
    {

        #region HTTP methods

        /// <summary>
        /// Corresponds to the HTTP Get method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="context">The optional call context to use</param>
        /// <typeparam name="T">Type of the response.</typeparam>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the Online Payments platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the Online Payments platform</exception>
        Task<T> Get<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders,
            AbstractParamRequest requestParameters,
            CallContext context);

        /// <summary>
        /// Corresponds to the HTTP Get method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="bodyHandler">A callback that receives the contents of the body as a stream</param>
        /// <param name="context">The optional call context to use</param>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the Online Payments platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the Online Payments platform</exception>
        /// <exception cref="BodyHandlerException">when the BodyHandler throws an exception</exception>
        Task Get(string relativePath, IEnumerable<IRequestHeader> requestHeaders,
            AbstractParamRequest requestParameters,
            Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context);

        /// <summary>
        /// Corresponds to the HTTP DELETE method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="context">The optional call context to use</param>
        /// <typeparam name="T">Type of the response.</typeparam>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the Online Payments platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the Online Payments platform</exception>
        Task<T> Delete<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders,
            AbstractParamRequest requestParameters,
            CallContext context);

        /// <summary>
        /// Corresponds to the HTTP DELETE method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="bodyHandler">A callback that receives the contents of the body as a stream</param>
        /// <param name="context">The optional call context to use</param>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the Online Payments platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the Online Payments platform</exception>
        /// <exception cref="BodyHandlerException">when the BodyHandler throws an exception</exception>
        Task Delete(string relativePath, IEnumerable<IRequestHeader> requestHeaders,
            AbstractParamRequest requestParameters,
            Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context);

        /// <summary>
        /// Corresponds to the HTTP POST method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="requestBody">The optional request body to send.</param>
        /// <param name="context">The optional call context to use</param>
        /// <typeparam name="T">Type of the response.</typeparam>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the Online Payments platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the Online Payments platform</exception>
        Task<T> Post<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders,
            AbstractParamRequest requestParameters,
            object requestBody, CallContext context);

        /// <summary>
        /// Corresponds to the HTTP POST method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="requestBody">The optional request body to send.</param>
        /// <param name="bodyHandler">A callback that receives the contents of the body as a stream</param>
        /// <param name="context">The optional call context to use</param>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the Online Payments platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the Online Payments platform</exception>
        /// <exception cref="BodyHandlerException">when the BodyHandler throws an exception</exception>
        Task Post(string relativePath, IEnumerable<IRequestHeader> requestHeaders,
            AbstractParamRequest requestParameters,
            object requestBody, Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context);

        /// <summary>
        /// Corresponds to the HTTP PUT method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="requestBody">The optional request body to send.</param>
        /// <param name="context">The optional call context to use</param>
        /// <typeparam name="T">Type of the response.</typeparam>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the Online Payments platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the Online Payments platform</exception>
        Task<T> Put<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders,
            AbstractParamRequest requestParameters,
            object requestBody, CallContext context);

        /// <summary>
        /// Corresponds to the HTTP PUT method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="requestBody">The optional request body to send.</param>
        /// <param name="bodyHandler">A callback that receives the contents of the body as a stream</param>
        /// <param name="context">The optional call context to use</param>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the Online Payments platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the Online Payments platform</exception>
        /// <exception cref="BodyHandlerException">when the BodyHandler throws an exception</exception>
        Task Put(string relativePath, IEnumerable<IRequestHeader> requestHeaders,
            AbstractParamRequest requestParameters,
            object requestBody, Action<Stream, IEnumerable<IResponseHeader>> bodyHandler, CallContext context);

        #endregion

        /// <summary>
        /// Gets the <see cref="IMarshaller"/> object associated with this communicator. Never <c>null</c>.
        /// </summary>
        IMarshaller Marshaller { get; }

        /// <summary>
        /// Utility method that delegates the call to this communicator's session's connection if that's an instance of <see cref="IPooledConnection"/>.
        /// If not this method does nothing.
        /// <seealso cref="IPooledConnection.CloseExpiredConnections"/>
        /// </summary>
        void CloseExpiredConnections();

        /// <summary>
        /// Utility method that delegates the call to this communicator's session's connection if that's an instance of
        /// <see cref="IPooledConnection"/>.
        /// </summary>
        /// <param name="timespan">Idle time.</param>
        void CloseIdleConnections(TimeSpan timespan);
    }
}

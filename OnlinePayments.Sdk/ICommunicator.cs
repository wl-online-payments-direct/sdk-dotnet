using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using OnlinePayments.Sdk.DefaultImpl;
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
    public interface ICommunicator : IDisposable, ILoggingCapable
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
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the payment platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the payment platform</exception>
        /// <exception cref="ApiException">when an error response was received from the payment platform which contained a list of errors</exception>
        Task<T> Get<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                    CallContext context);

        /// <summary>
        /// Corresponds to the HTTP DELETE method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="context">The optional call context to use</param>
        /// <typeparam name="T">Type of the response.</typeparam>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the payment platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the payment platform</exception>
        /// <exception cref="ApiException">when an error response was received from the payment platform which contained a list of errors</exception>
        Task<T> Delete<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                       CallContext context);

        /// <summary>
        /// Corresponds to the HTTP POST method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="requestBody">The optional request body to send.</param>
        /// <param name="context">The optional call context to use</param>
        /// <typeparam name="T">Type of the response.</typeparam>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the payment platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the payment platform</exception>
        /// <exception cref="ApiException">when an error response was received from the payment platform which contained a list of errors</exception>
        Task<T> Post<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                     object requestBody, CallContext context);

        /// <summary>
        /// Corresponds to the HTTP PUT method.
        /// </summary>
        /// <param name="relativePath">The path to call, relative to the base URI.</param>
        /// <param name="requestHeaders">An optional list of request headers.</param>
        /// <param name="requestParameters">The optional set of request parameters.</param>
        /// <param name="requestBody">The optional request body to send.</param>
        /// <param name="context">The optional call context to use</param>
        /// <typeparam name="T">Type of the response.</typeparam>
        /// <exception cref="CommunicationException"> when an exception occurred communicating with the payment platform</exception>
        /// <exception cref="ResponseException">when an error response was received from the payment platform</exception>
        /// <exception cref="ApiException">when an error response was received from the payment platform which contained a list of errors</exception>
        Task<T> Put<T>(string relativePath, IEnumerable<IRequestHeader> requestHeaders, AbstractParamRequest requestParameters,
                                    object requestBody, CallContext context);
        #endregion

        /// <summary>
        /// Unmarshal a JSON string to a response object.
        /// </summary>
        /// <param name="responseJson">The JSON that will be parsed.</param>
        /// <typeparam name="T">The response type.</typeparam>
        /// <exception cref="MarshallerSyntaxException">if the JSON is not a valid representation for an object of the given type</exception>
        T Unmarshal<T>(string responseJson);

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

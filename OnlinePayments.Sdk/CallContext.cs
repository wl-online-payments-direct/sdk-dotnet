using System;

namespace OnlinePayments.Sdk
{
    /// <summary>
    /// A call context can be used to send extra information with a request, and to receive extra information from a response.
    /// Please note that this class is not thread-safe. Each request should get its own call context instance.
    /// </summary>
    public class CallContext
    {
        public string IdempotenceKey { get; private set; }

        /// <summary>
        /// Sets the idempotence key to use for the next request for which this call context is used.
        /// </summary>
        /// <param name="idempotenceKey">Idempotence key.</param>
        /// <returns>This.</returns>
        public CallContext WithIdempotenceKey(string idempotenceKey)
        {
            IdempotenceKey = idempotenceKey;
            return this;
        }

        /// <summary>
        /// The idempotence request timestamp from the response to the
        /// last request for which this call context was used.
        /// </summary>
        /// <value>The idempotence request timestamp.</value>
        /// <remarks>Returns <c>null</c> if no idempotence request was present.
        /// The property should only be set by <see cref="ICommunicator"/> objects based
        /// on the response to the request for which this call context was used.
        /// </remarks>
        public long? IdempotenceRequestTimestamp { get; set; }

        /// <summary>
        /// The idempotence response date/time from the response to the
        /// last request for which this call context was used.
        /// </summary>
        /// <value>The idempotence response date/time.</value>
        /// <remarks>Returns <c>null</c> if no idempotence request was present.
        /// The property should only be set by <see cref="ICommunicator"/> objects based
        /// on the response to the request for which this call context was used.
        /// </remarks>
        public DateTimeOffset? IdempotenceResponseDateTime { get; set; }
    }
}

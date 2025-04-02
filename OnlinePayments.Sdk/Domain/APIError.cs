/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class APIError
    {
        /// <summary>
        /// Category the error belongs to. The category should give an indication of the type of error you are dealing with. Possible values:
        /// <list type="bullet">
        ///   <item><description>DIRECT_PLATFORM_ERROR - indicating that a functional error has occurred in the platform.</description></item>
        ///   <item><description>PAYMENT_PLATFORM_ERROR - indicating that a functional error has occurred in the payment platform.</description></item>
        ///   <item><description>IO_ERROR - indicating that a technical error has occurred within the payment platform or between the payment platform and third party systems.</description></item>
        /// </list>
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Deprecated: Use errorCode instead.
        /// Error code
        /// </summary>
        [Obsolete("Use errorCode instead. Error code")]
        public string Code { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// HTTP status code for this error that can be used to determine the type of error
        /// </summary>
        public int? HttpStatusCode { get; set; }

        /// <summary>
        /// ID of the error. This is a short human-readable message that briefly describes the error.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Human-readable error message that is not meant to be relayed to customer as it might tip off people who are trying to commit fraud
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Returned only if the error relates to a value that was missing or incorrect.
        /// <p />
        /// Contains a location path to the value as a JSonata query.
        /// <p />
        /// Some common examples:
        /// <list type="bullet">
        ///   <item><description>a.b selects the value of property b of root property a,</description></item>
        ///   <item><description>a[1] selects the first element of the array in root property a,</description></item>
        ///   <item><description>a[b='some value'] selects all elements of the array in root property a that have a property b with value 'some value'.</description></item>
        /// </list>
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Flag indicating if the request is retriable.
        /// Retriable requests mean that a technical error happened and that the same request can safely be sent again with a new idempotence key.
        /// </summary>
        public bool? Retriable { get; set; }
    }
}

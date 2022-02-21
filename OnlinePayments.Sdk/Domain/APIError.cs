/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class APIError
    {
        /// <summary>
        /// Category the error belongs to. The category should give an indication of the type of error you are dealing with. Possible values:<para />
        /// * DIRECT_PLATFORM_ERROR - indicating that a functional error has occurred in the platform.<para />
        /// * PAYMENT_PLATFORM_ERROR - indicating that a functional error has occurred in the payment platform.<para />
        /// * IO_ERROR - indicating that a technical error has occurred within the Direct platform or between Direct and any of the payment platforms or third party systems.<para />
        /// </summary>
        public string Category { get; set; } = null;

        /// <summary>
        /// Error code<para />
        /// </summary>
        public string Code { get; set; } = null;

        /// <summary>
        /// HTTP status code for this error that can be used to determine the type of error<para />
        /// </summary>
        public int? HttpStatusCode { get; set; } = null;

        /// <summary>
        /// ID of the error. This is a short human-readable message that briefly describes the error.<para />
        /// </summary>
        public string Id { get; set; } = null;

        /// <summary>
        /// Human-readable error message that is not meant to be relayed to customer as it might tip off people who are trying to commit fraud<para />
        /// </summary>
        public string Message { get; set; } = null;

        /// <summary>
        /// Returned only if the error relates to a value that was missing or incorrect.<para />
        /// <para />
        /// Contains a location path to the value as a JSonata query.<para />
        /// <para />
        /// Some common examples:<para />
        /// * a.b selects the value of property b of root property a,<para />
        /// * a[1] selects the first element of the array in root property a,<para />
        /// * a[b='some value'] selects all elements of the array in root property a that have a property b with value 'some value'.<para />
        /// </summary>
        public string PropertyName { get; set; } = null;
    }
}

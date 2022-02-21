/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateMandateWithReturnUrl
    {
        /// <summary>
        /// An alias for the mandate. This can be used to visually represent the mandate. Do not include any unmasked sensitive data in the alias. If this field is not provided the masked IBAN of the customer is used.<para />
        /// </summary>
        public string Alias { get; set; } = null;

        /// <summary>
        /// Customer object containing customer specific inputs.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// </summary>
        public MandateCustomer Customer { get; set; } = null;

        /// <summary>
        /// The unique identifier of a customer<para />
        /// </summary>
        public string CustomerReference { get; set; } = null;

        /// <summary>
        /// The language code of the customer. ISO 639-1, possible values are:<para />
        /// * de<para />
        /// * en<para />
        /// * es<para />
        /// * fr<para />
        /// * it<para />
        /// * nl<para />
        /// * si<para />
        /// * sk<para />
        /// * sv<para />
        /// </summary>
        public string Language { get; set; } = null;

        /// <summary>
        /// Specifies whether the mandate is for one-off or recurring payments. Possible values are:<para />
        /// * UNIQUE<para />
        /// * RECURRING<para />
        /// </summary>
        public string RecurrenceType { get; set; } = null;

        /// <summary>
        /// Return URL to use if the mandate signing requires redirection. Required for S2S Create Payment if and only if the signatureType is "SMS".<para />
        /// </summary>
        public string ReturnUrl { get; set; } = null;

        /// <summary>
        /// Specifies whether the mandate is unsigned or signed by SMS. Possible values are:<para />
        /// * UNSIGNED<para />
        /// * SMS<para />
        /// </summary>
        public string SignatureType { get; set; } = null;

        /// <summary>
        /// The unique identifier of the mandate<para />
        /// </summary>
        public string UniqueMandateReference { get; set; } = null;
    }
}

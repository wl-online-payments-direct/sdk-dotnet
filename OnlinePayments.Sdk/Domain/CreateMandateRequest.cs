/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateMandateRequest
    {
        /// <summary>
        /// An alias for the mandate. This can be used to visually represent the mandate. Do not include any unmasked sensitive data in the alias. If this field is not provided the masked IBAN of the customer is used.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Customer object containing customer specific inputs.
        /// Required for Create mandate and Create payment calls.
        /// </summary>
        public MandateCustomer Customer { get; set; }

        /// <summary>
        /// The unique identifier of a customer
        /// </summary>
        public string CustomerReference { get; set; }

        /// <summary>
        /// The language code of the customer. ISO 639-1, possible values are:
        /// <list type="bullet">
        ///   <item><description>de</description></item>
        ///   <item><description>en</description></item>
        ///   <item><description>es</description></item>
        ///   <item><description>fr</description></item>
        ///   <item><description>it</description></item>
        ///   <item><description>nl</description></item>
        ///   <item><description>si</description></item>
        ///   <item><description>sk</description></item>
        ///   <item><description>sv</description></item>
        /// </list>
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Specifies whether the mandate is for one-off or recurring payments. Possible values are:
        /// <list type="bullet">
        ///   <item><description>UNIQUE</description></item>
        ///   <item><description>RECURRING</description></item>
        /// </list>
        /// </summary>
        public string RecurrenceType { get; set; }

        /// <summary>
        /// Return URL to use if the mandate signing requires redirection. Required for S2S Create Payment if and only if the signatureType is &quot;SMS&quot; or &quot;AIS&quot;.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Specifies whether the mandate is unsigned, signed by SMS or tick box. Possible values are:
        /// <list type="bullet">
        ///   <item><description>UNSIGNED</description></item>
        ///   <item><description>SMS</description></item>
        ///   <item><description>TICK_BOX</description></item>
        ///   <item><description>AIS</description></item>
        /// </list>
        /// <p />
        /// Refer to the support page to determine the applicable signature types.
        /// </summary>
        public string SignatureType { get; set; }

        /// <summary>
        /// The unique identifier of the mandate
        /// </summary>
        public string UniqueMandateReference { get; set; }
    }
}

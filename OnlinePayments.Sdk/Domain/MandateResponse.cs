/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateResponse
    {
        /// <summary>
        /// An alias for the mandate. This can be used to visually represent the mandate. Do not include any unmasked sensitive data in the alias. If this field is not provided the masked IBAN of the customer is used.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Customer object containing customer specific outputs.
        /// </summary>
        public MandateCustomerResponse Customer { get; set; }

        /// <summary>
        /// The unique identifier of a customer
        /// </summary>
        public string CustomerReference { get; set; }

        /// <summary>
        /// The mandate PDF in base64 encoded string
        /// </summary>
        public string MandatePdf { get; set; }

        /// <summary>
        /// Specifies whether the mandate is for one-off or recurring payments. Possible values are:
        /// <list type="bullet">
        ///   <item><description>UNIQUE</description></item>
        ///   <item><description>RECURRING</description></item>
        /// </list>
        /// </summary>
        public string RecurrenceType { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// The unique identifier of the mandate
        /// </summary>
        public string UniqueMandateReference { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateResponse WithAlias(string value)
        {
            Alias = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateResponse WithCustomer(MandateCustomerResponse value)
        {
            Customer = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateResponse WithCustomerReference(string value)
        {
            CustomerReference = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateResponse WithMandatePdf(string value)
        {
            MandatePdf = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateResponse WithRecurrenceType(string value)
        {
            RecurrenceType = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateResponse WithStatus(string value)
        {
            Status = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateResponse WithUniqueMandateReference(string value)
        {
            UniqueMandateReference = value;
            return this;
        }
    }
}

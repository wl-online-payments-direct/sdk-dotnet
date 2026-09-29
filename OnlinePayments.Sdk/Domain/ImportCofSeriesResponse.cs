/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ImportCofSeriesResponse
    {
        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string PaymentId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ImportCofSeriesResponse WithPaymentId(string value)
        {
            PaymentId = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MultiplePaymentInformation
    {
        /// <summary>
        /// Typology of multiple payment. Allowed values:
        /// <list type="bullet">
        ///   <item><description>PartialShipment</description></item>
        /// </list>
        /// </summary>
        public string PaymentPattern { get; set; }

        /// <summary>
        /// Total number of payments. If a payment is implied by this call, it implicitly has ordinal number 1.
        /// </summary>
        public int? TotalNumberOfPayments { get; set; }
    }
}

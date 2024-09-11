/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MultiplePaymentInformation
    {
        /// <summary>
        /// Typology of multiple payment. Allowed values:<para />
        ///   * PartialShipment<para />
        /// </summary>
        public string PaymentPattern { get; set; } = null;

        /// <summary>
        /// Total number of payments. If a payment is implied by this call, it implicitly has ordinal number 1.<para />
        /// </summary>
        public int? TotalNumberOfPayments { get; set; } = null;
    }
}

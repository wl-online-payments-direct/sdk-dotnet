/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PayoutStatusOutput
    {
        /// <summary>
        /// Flag indicating if the payout can be cancelled <para />
        ///  * true <para />
        ///  * false<para />
        /// </summary>
        public bool? IsCancellable { get; set; } = null;

        /// <summary>
        /// Highlevel status of the payment, payout or refund.<para />
        /// </summary>
        public string StatusCategory { get; set; } = null;

        /// <summary>
        /// Numeric status code of the legacy API. It is returned to ease the migration from the legacy APIs. You should not write new business logic based on this property as it will be deprecated in a future version of the API. The value can also be found in the BackOffice and in report files.<para />
        /// </summary>
        public int? StatusCode { get; set; } = null;
    }
}

/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PayoutOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Allows you to additionally specify the reason for initiating the payout for authorization purposes. If this field is not specified, authorisation of the payment will be made according to your merchant profile. Possible values are:<para />
        ///   * Gambling<para />
        ///   * Refund<para />
        ///   * Loyalty<para />
        /// </summary>
        public string PayoutReason { get; set; } = null;
    }
}

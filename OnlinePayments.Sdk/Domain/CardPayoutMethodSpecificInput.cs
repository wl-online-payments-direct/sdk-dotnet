/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPayoutMethodSpecificInput
    {
        /// <summary>
        /// Object containing card details<para />
        /// </summary>
        public Card Card { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// Allows you to additionally specify the reason for initiating the payout for authorization purposes. If this field is not specified, authorisation of the payment will be made according to your merchant profile. Possible values are:<para />
        ///   * Gambling<para />
        ///   * Refund<para />
        ///   * Loyalty<para />
        /// </summary>
        public string PayoutReason { get; set; } = null;

        /// <summary>
        /// ID of the token<para />
        /// </summary>
        public string Token { get; set; } = null;
    }
}

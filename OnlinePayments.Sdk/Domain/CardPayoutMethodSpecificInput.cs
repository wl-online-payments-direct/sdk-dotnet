/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPayoutMethodSpecificInput
    {
        /// <summary>
        /// Object containing card details
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Allows you to additionally specify the reason for initiating the payout for authorization purposes. If this field is not specified, authorisation of the payment will be made according to your merchant profile. Possible values are:
        /// <list type="bullet">
        ///   <item><description>Gambling</description></item>
        ///   <item><description>Refund</description></item>
        ///   <item><description>Loyalty</description></item>
        /// </list>
        /// </summary>
        public string PayoutReason { get; set; }

        /// <summary>
        /// ID of the token
        /// </summary>
        public string Token { get; set; }
    }
}

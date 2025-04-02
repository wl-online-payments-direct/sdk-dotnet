/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PayoutOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Allows you to additionally specify the reason for initiating the payout for authorization purposes. If this field is not specified, authorisation of the payment will be made according to your merchant profile. Possible values are:
        /// <list type="bullet">
        ///   <item><description>Gambling</description></item>
        ///   <item><description>Refund</description></item>
        ///   <item><description>Loyalty</description></item>
        /// </list>
        /// </summary>
        public string PayoutReason { get; set; }
    }
}

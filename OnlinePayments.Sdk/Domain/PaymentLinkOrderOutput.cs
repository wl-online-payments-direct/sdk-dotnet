/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkOrderOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney Amount { get; set; } = null;

        /// <summary>
        /// Your unique reference of the transaction that is also returned in our report files. This is almost always used for your reconciliation of our report files.<para />
        /// It is highly recommended to provide a single MerchantReference per unique order on your side<para />
        /// </summary>
        public string MerchantReference { get; set; } = null;
    }
}

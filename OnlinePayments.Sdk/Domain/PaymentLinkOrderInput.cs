/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkOrderInput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney Amount { get; set; }

        /// <summary>
        /// Your unique reference of the transaction that is also returned in our report files. This is almost always used for your reconciliation of our report files.
        /// It is highly recommended to provide a single MerchantReference per unique order on your side
        /// </summary>
        public string MerchantReference { get; set; }

        /// <summary>
        /// Object containing details how surcharge will be applied to a payment link.
        /// </summary>
        public SurchargeForPaymentLink SurchargeSpecificInput { get; set; }
    }
}

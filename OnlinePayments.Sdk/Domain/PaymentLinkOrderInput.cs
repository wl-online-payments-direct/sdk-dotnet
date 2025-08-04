/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    [Obsolete("An object containing the details of the related payment input.  All properties in paymentLinkOrder are deprecated. Use corresponding values as noted below: | Property | Replacement | | - | - | | merchantReference | references/merchantReference | | amount | order/amountOfMoney | | surchargeSpecificInput | order/surchargeSpecificInput |")]
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

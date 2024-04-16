/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SurchargeForPaymentLink
    {
        /// <summary>
        /// The surcharge mode which defines how a merchant will apply surcharging.<para />
        /// * pass-through - Merchant to define and apply surcharge amount for a transaction for processing. This mode is not supported on Create Hosted Checkout Session.<para />
        /// * on-behalf-of - Merchant to instruct the payment platform to calculate and apply a surcharge amount to a transaction, based on the merchant’s surcharge configuration, net amount, and payment product type.<para />
        /// </summary>
        public string SurchargeMode { get; set; } = null;
    }
}

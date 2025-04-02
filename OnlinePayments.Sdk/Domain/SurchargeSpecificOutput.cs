/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SurchargeSpecificOutput
    {
        /// <summary>
        /// The surcharge mode which defines how a merchant will apply surcharging.
        /// <list type="bullet">
        ///   <item><description>pass-through - Merchant to define and apply surcharge amount for a transaction for processing. This mode is not supported on Create Hosted Checkout Session.</description></item>
        ///   <item><description>on-behalf-of - Merchant to instruct the payment platform to calculate and apply a surcharge amount to a transaction, based on the merchantâ€™s surcharge configuration, net amount, and payment product type.</description></item>
        /// </list>
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney SurchargeAmount { get; set; }

        /// <summary>
        /// A summary of surcharge details used in the calculation of the surcharge amount. null if result = NO_SURCHARGE
        /// </summary>
        public SurchargeRate SurchargeRate { get; set; }
    }
}

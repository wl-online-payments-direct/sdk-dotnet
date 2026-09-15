/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SurchargeSpecificOutput
    {
        /// <summary>
        /// The surcharge mode applied to an order.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// The surcharge amount of money applied to an order.
        /// </summary>
        public AmountOfMoney SurchargeAmount { get; set; }

        /// <summary>
        /// A summary of surcharge details used in the calculation of the surcharge amount.  Null if result = NO_SURCHARGE
        /// </summary>
        public SurchargeRate SurchargeRate { get; set; }
    }
}

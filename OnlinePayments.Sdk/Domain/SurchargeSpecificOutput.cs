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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SurchargeSpecificOutput WithMode(string value)
        {
            Mode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SurchargeSpecificOutput WithSurchargeAmount(AmountOfMoney value)
        {
            SurchargeAmount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SurchargeSpecificOutput WithSurchargeRate(SurchargeRate value)
        {
            SurchargeRate = value;
            return this;
        }
    }
}

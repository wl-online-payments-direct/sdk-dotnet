/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SurchargeSpecificInput
    {
        /// <summary>
        /// The surcharge mode to be applied to an order.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// The surcharge amount of money to be applied to an order given that the merchant is in pass-through mode.
        /// </summary>
        public AmountOfMoney SurchargeAmount { get; set; }
    }
}

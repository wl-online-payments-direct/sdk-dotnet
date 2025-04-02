/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Surcharge
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney NetAmount { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Token describing result. OK - A Surcharge Amount was successfully calculated, NO_SURCHARGE - A configured surcharge rate could not be found for the payment product
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney SurchargeAmount { get; set; }

        /// <summary>
        /// A summary of surcharge details used in the calculation of the surcharge amount. null if result = NO_SURCHARGE
        /// </summary>
        public SurchargeRate SurchargeRate { get; set; }

        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney TotalAmount { get; set; }
    }
}

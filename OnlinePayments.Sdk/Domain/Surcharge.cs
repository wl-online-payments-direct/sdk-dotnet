/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Surcharge
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney NetAmount { get; set; } = null;

        /// <summary>
        /// The payment product identifier.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// Token describing result. OK - A Surcharge Amount was successfully calculated, NO_SURCHARGE - A configured surcharge rate could not be found for the payment product<para />
        /// </summary>
        public string Result { get; set; } = null;

        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney SurchargeAmount { get; set; } = null;

        /// <summary>
        /// A summary of surcharge details used in the calculation of the surcharge amount. null if result = NO_SURCHARGE<para />
        /// </summary>
        public SurchargeRate SurchargeRate { get; set; } = null;

        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney TotalAmount { get; set; } = null;
    }
}

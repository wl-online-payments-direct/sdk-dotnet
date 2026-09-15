/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Surcharge
    {
        /// <summary>
        /// The amount of money to be charged to a payer not including any surcharge amount.
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
        /// The amount of money to be charged to a payer, in addition to the net amount to cover the cost of processing that payment.  This value is calculated on the payment amount provided in the request, and the applicable ad valorem and/or specific surcharge rate configured for the merchant, for that payment.
        /// </summary>
        public AmountOfMoney SurchargeAmount { get; set; }

        /// <summary>
        /// A summary of surcharge details used in the calculation of the surcharge amount.  Null if result = NO_SURCHARGE
        /// </summary>
        public SurchargeRate SurchargeRate { get; set; }

        /// <summary>
        /// The amount of money to be charged to a payer including any applicable surcharge. If you intend to apply additional services to the transaction before processing payment (such as DCC- Dynamic Currency Conversion), it is important to use this amount containing the surcharge instead of the net amount.
        /// </summary>
        public AmountOfMoney TotalAmount { get; set; }
    }
}

/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentMethodSpecificOutput
    {
        /// <summary>
        /// Object containing the results of the fraud screening<para />
        /// </summary>
        public FraudResults FraudResults { get; set; } = null;

        /// <summary>
        /// The specific payment option for the payment. To be used as a complement of the more generic paymentProductId (oney, banquecasino, cofidis), which allows to define a variation of the selected paymentProductId (ex: facilypay3x, banquecasino4x, cofidis3x-sansfrais, ...). List of modalities included in the payment product page.<para />
        /// </summary>
        public string PaymentOption { get; set; } = null;

        /// <summary>
        /// Meal vouchers (payment product 5402) specific details<para />
        /// </summary>
        public PaymentProduct5402SpecificOutput PaymentProduct5402SpecificOutput { get; set; } = null;

        /// <summary>
        /// Multibanco (payment product 5500) specific details<para />
        /// </summary>
        public PaymentProduct5500SpecificOutput PaymentProduct5500SpecificOutput { get; set; } = null;

        /// <summary>
        /// PayPal (payment product 840) specific details<para />
        /// </summary>
        public PaymentProduct840SpecificOutput PaymentProduct840SpecificOutput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// ID of the token. This property is populated when the payment was done with a token or when the payment was tokenized.<para />
        /// </summary>
        public string Token { get; set; } = null;
    }
}

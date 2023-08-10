/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentMethodSpecificInput
    {
        /// <summary>
        /// The specific payment option for the payment. To be used as a complement of the more generic paymentProductId (oney, banquecasino, cofidis), which allows to define a variation of the selected paymentProductId (ex: facilypay3x, banquecasino4x, cofidis3x-sansfrais, ...). List of modalities included in the payment product page.<para />
        /// </summary>
        public string PaymentOption { get; set; } = null;

        /// <summary>
        /// Object containing specific input required for Klarna payments (Payment product ID 3306)<para />
        /// </summary>
        public RedirectPaymentProduct3306SpecificInput PaymentProduct3306SpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing specific input for EPS payments (Payment product ID 5406)<para />
        /// </summary>
        public RedirectPaymentProduct5406SpecificInput PaymentProduct5406SpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing specific input required for iDeal payments (Payment product ID 809)<para />
        /// </summary>
        public RedirectPaymentProduct809SpecificInput PaymentProduct809SpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing specific input required for PayPal payments (Payment product ID 840)<para />
        /// </summary>
        public RedirectPaymentProduct840SpecificInput PaymentProduct840SpecificInput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// Object containing browser specific redirection related data<para />
        /// </summary>
        public RedirectionData RedirectionData { get; set; } = null;

        /// <summary>
        /// * true = the payment requires approval before the funds will be captured using the Approve payment or Capture payment API<para />
        /// * false = the payment does not require approval, and the funds will be captured automatically<para />
        /// </summary>
        public bool? RequiresApproval { get; set; } = null;

        /// <summary>
        /// ID of the token to use to create the payment.<para />
        /// </summary>
        public string Token { get; set; } = null;

        /// <summary>
        /// Indicates if this transaction should be tokenized<para />
        ///   * true - Tokenize the transaction.<para />
        ///   * false - Do not tokenize the transaction, unless it would be tokenized by other means such as auto-tokenization of recurring payments.<para />
        /// </summary>
        public bool? Tokenize { get; set; } = null;
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentMethodSpecificInput
    {
        /// <summary>
        /// The specific payment option for the payment. To be used as a complement of the more generic paymentProductId (oney, banquecasino, cofidis), which allows to define a variation of the selected paymentProductId (ex: facilypay3x, banquecasino4x, cofidis3x-sansfrais, ...). List of modalities included in the payment product page.
        /// </summary>
        public string PaymentOption { get; set; }

        /// <summary>
        /// Object contains the inputs required to perform a bank transfer using payment product 11.
        /// </summary>
        public RedirectPaymentProduct11SpecificInput PaymentProduct11SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input for PostFinancePay payments (Payment product ID 3203).
        /// </summary>
        public RedirectPaymentProduct3203SpecificInput PaymentProduct3203SpecificInput { get; set; }

        /// <summary>
        /// BLIK (payment product 3204) specific details
        /// </summary>
        public RedirectPaymentProduct3204SpecificInput PaymentProduct3204SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Klarna PayLater payment (Payment product ID 3302)
        /// </summary>
        public RedirectPaymentProduct3302SpecificInput PaymentProduct3302SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Klarna payments (Payment product ID 3306)
        /// </summary>
        public RedirectPaymentProduct3306SpecificInput PaymentProduct3306SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Klarna payments (Payment product ID 3307)
        /// </summary>
        public RedirectPaymentProduct3307SpecificInput PaymentProduct3307SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Bizum payments
        /// </summary>
        public RedirectPaymentProduct5001SpecificInput PaymentProduct5001SpecificInput { get; set; }

        /// <summary>
        /// Pledg (payment product 5300) specific details
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput PaymentProduct5300SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for E-Voucher payments (Payment product ID 5402)
        /// </summary>
        public RedirectPaymentProduct5402SpecificInput PaymentProduct5402SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Chèque-Vacances Connect payments via Limonetik (Payment product ID 5403)
        /// </summary>
        public RedirectPaymentProduct5403SpecificInput PaymentProduct5403SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input for EPS payments (Payment product ID 5406)
        /// </summary>
        public RedirectPaymentProduct5406SpecificInput PaymentProduct5406SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input for Account to Account payments (Payment product ID 5408)
        /// </summary>
        public RedirectPaymentProduct5408SpecificInput PaymentProduct5408SpecificInput { get; set; }

        /// <summary>
        /// iDealin3 (payment product 5410) specific details
        /// </summary>
        public RedirectPaymentProduct5410SpecificInput PaymentProduct5410SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Chèque-Vacances Connect payments via ANCV (Payment product ID 5412)
        /// </summary>
        public RedirectPaymentProduct5412SpecificInput PaymentProduct5412SpecificInput { get; set; }

        /// <summary>
        /// Deprecated, this is no longer used.
        /// </summary>
        public RedirectPaymentProduct809SpecificInput PaymentProduct809SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for PayPal payments (Payment product ID 840)
        /// </summary>
        public RedirectPaymentProduct840SpecificInput PaymentProduct840SpecificInput { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Object containing browser specific redirection related data
        /// </summary>
        public RedirectionData RedirectionData { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true = the payment requires approval before the funds will be captured using the Approve payment or Capture payment API</description></item>
        ///   <item><description>false = the payment does not require approval, and the funds will be captured automatically</description></item>
        /// </list>
        /// </summary>
        public bool? RequiresApproval { get; set; }

        /// <summary>
        /// ID of the token to use to create the payment.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Indicates if this transaction should be tokenized
        /// <list type="bullet">
        ///   <item><description>true - Tokenize the transaction.</description></item>
        ///   <item><description>false - Do not tokenize the transaction, unless it would be tokenized by other means such as auto-tokenization of recurring payments.</description></item>
        /// </list>
        /// </summary>
        public bool? Tokenize { get; set; }
    }
}

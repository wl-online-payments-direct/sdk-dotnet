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
        /// Object containing specific input for CadoCarte payments (Payment product ID 3103)
        /// </summary>
        public RedirectPaymentProduct3103SpecificInput PaymentProduct3103SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Illicado payments (Payment product ID 3112)
        /// </summary>
        public RedirectPaymentProduct3112SpecificInput PaymentProduct3112SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input for SpiritOfCadeau payments (Payment product ID 3116)
        /// </summary>
        public RedirectPaymentProduct3116SpecificInput PaymentProduct3116SpecificInput { get; set; }

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
        /// PAYONE Buy Now, Pay Later (payment product 5301) specific details
        /// </summary>
        public RedirectPaymentProduct5301SpecificInput PaymentProduct5301SpecificInput { get; set; }

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
        /// TWINT (payment product 5407) specific details
        /// </summary>
        public RedirectPaymentProduct5407SpecificInput PaymentProduct5407SpecificInput { get; set; }

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
        /// Object containing specific input for Cadhoc payments (Payment product ID 5601)
        /// </summary>
        public RedirectPaymentProduct5601SpecificInput PaymentProduct5601SpecificInput { get; set; }

        /// <summary>
        /// Deprecated, this is no longer used.
        /// </summary>
        public RedirectPaymentProduct809SpecificInput PaymentProduct809SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for PayPal payments (Payment product ID 840)
        /// </summary>
        public RedirectPaymentProduct840SpecificInput PaymentProduct840SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Wero payments (Payment product ID 900)
        /// </summary>
        public RedirectPaymentProduct900SpecificInput PaymentProduct900SpecificInput { get; set; }

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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentOption(string value)
        {
            PaymentOption = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct11SpecificInput(RedirectPaymentProduct11SpecificInput value)
        {
            PaymentProduct11SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct3103SpecificInput(RedirectPaymentProduct3103SpecificInput value)
        {
            PaymentProduct3103SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct3112SpecificInput(RedirectPaymentProduct3112SpecificInput value)
        {
            PaymentProduct3112SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct3116SpecificInput(RedirectPaymentProduct3116SpecificInput value)
        {
            PaymentProduct3116SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct3203SpecificInput(RedirectPaymentProduct3203SpecificInput value)
        {
            PaymentProduct3203SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct3204SpecificInput(RedirectPaymentProduct3204SpecificInput value)
        {
            PaymentProduct3204SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct3302SpecificInput(RedirectPaymentProduct3302SpecificInput value)
        {
            PaymentProduct3302SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct3306SpecificInput(RedirectPaymentProduct3306SpecificInput value)
        {
            PaymentProduct3306SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct3307SpecificInput(RedirectPaymentProduct3307SpecificInput value)
        {
            PaymentProduct3307SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5001SpecificInput(RedirectPaymentProduct5001SpecificInput value)
        {
            PaymentProduct5001SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5300SpecificInput(RedirectPaymentProduct5300SpecificInput value)
        {
            PaymentProduct5300SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5301SpecificInput(RedirectPaymentProduct5301SpecificInput value)
        {
            PaymentProduct5301SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5402SpecificInput(RedirectPaymentProduct5402SpecificInput value)
        {
            PaymentProduct5402SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5403SpecificInput(RedirectPaymentProduct5403SpecificInput value)
        {
            PaymentProduct5403SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5406SpecificInput(RedirectPaymentProduct5406SpecificInput value)
        {
            PaymentProduct5406SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5407SpecificInput(RedirectPaymentProduct5407SpecificInput value)
        {
            PaymentProduct5407SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5408SpecificInput(RedirectPaymentProduct5408SpecificInput value)
        {
            PaymentProduct5408SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5410SpecificInput(RedirectPaymentProduct5410SpecificInput value)
        {
            PaymentProduct5410SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5412SpecificInput(RedirectPaymentProduct5412SpecificInput value)
        {
            PaymentProduct5412SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct5601SpecificInput(RedirectPaymentProduct5601SpecificInput value)
        {
            PaymentProduct5601SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct809SpecificInput(RedirectPaymentProduct809SpecificInput value)
        {
            PaymentProduct809SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct840SpecificInput(RedirectPaymentProduct840SpecificInput value)
        {
            PaymentProduct840SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProduct900SpecificInput(RedirectPaymentProduct900SpecificInput value)
        {
            PaymentProduct900SpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithRedirectionData(RedirectionData value)
        {
            RedirectionData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithRequiresApproval(bool? value)
        {
            RequiresApproval = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithToken(string value)
        {
            Token = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificInput WithTokenize(bool? value)
        {
            Tokenize = value;
            return this;
        }
    }
}

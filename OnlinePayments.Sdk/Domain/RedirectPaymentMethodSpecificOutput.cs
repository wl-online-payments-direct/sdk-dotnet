/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentMethodSpecificOutput
    {
        /// <summary>
        /// Card Authorization code as returned by the acquirer
        /// </summary>
        public string AuthorisationCode { get; set; }

        /// <summary>
        /// Data of customer bank account
        /// </summary>
        public CustomerBankAccount CustomerBankAccount { get; set; }

        /// <summary>
        /// Object containing the results of the fraud screening
        /// </summary>
        public FraudResults FraudResults { get; set; }

        /// <summary>
        /// BLIK (payment product 3204) specific details
        /// </summary>
        public PaymentProduct3204SpecificOutput PaymentMethod3204SpecificOutput { get; set; }

        /// <summary>
        /// The specific payment option for the payment. To be used as a complement of the more generic paymentProductId (oney, banquecasino, cofidis), which allows to define a variation of the selected paymentProductId (ex: facilypay3x, banquecasino4x, cofidis3x-sansfrais, ...). List of modalities included in the payment product page.
        /// </summary>
        public string PaymentOption { get; set; }

        /// <summary>
        /// PostFinancePay (payment product 3203) specific details
        /// </summary>
        public PaymentProduct3203SpecificOutput PaymentProduct3203SpecificOutput { get; set; }

        /// <summary>
        /// Bizum (payment product 5001) specific details
        /// </summary>
        public PaymentProduct5001SpecificOutput PaymentProduct5001SpecificOutput { get; set; }

        /// <summary>
        /// Meal vouchers (payment product 5402) specific details
        /// </summary>
        public PaymentProduct5402SpecificOutput PaymentProduct5402SpecificOutput { get; set; }

        /// <summary>
        /// Multibanco (payment product 5500) specific details
        /// </summary>
        public PaymentProduct5500SpecificOutput PaymentProduct5500SpecificOutput { get; set; }

        /// <summary>
        /// PayPal (payment product 840) specific details
        /// </summary>
        public PaymentProduct840SpecificOutput PaymentProduct840SpecificOutput { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// ID of the token. This property is populated when the payment was done with a token or when the payment was tokenized.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithAuthorisationCode(string value)
        {
            AuthorisationCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithCustomerBankAccount(CustomerBankAccount value)
        {
            CustomerBankAccount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithFraudResults(FraudResults value)
        {
            FraudResults = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithPaymentMethod3204SpecificOutput(PaymentProduct3204SpecificOutput value)
        {
            PaymentMethod3204SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithPaymentOption(string value)
        {
            PaymentOption = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithPaymentProduct3203SpecificOutput(PaymentProduct3203SpecificOutput value)
        {
            PaymentProduct3203SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithPaymentProduct5001SpecificOutput(PaymentProduct5001SpecificOutput value)
        {
            PaymentProduct5001SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithPaymentProduct5402SpecificOutput(PaymentProduct5402SpecificOutput value)
        {
            PaymentProduct5402SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithPaymentProduct5500SpecificOutput(PaymentProduct5500SpecificOutput value)
        {
            PaymentProduct5500SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithPaymentProduct840SpecificOutput(PaymentProduct840SpecificOutput value)
        {
            PaymentProduct840SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentMethodSpecificOutput WithToken(string value)
        {
            Token = value;
            return this;
        }
    }
}

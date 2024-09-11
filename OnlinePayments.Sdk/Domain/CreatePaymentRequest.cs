/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePaymentRequest
    {
        /// <summary>
        /// Object containing the specific input details for card payments<para />
        /// </summary>
        public CardPaymentMethodSpecificInput CardPaymentMethodSpecificInput { get; set; } = null;

        /// <summary>
        /// Data that was encrypted client side containing all customer entered data elements like card data.<para />
        /// Note: Because this data can only be submitted once to our system and contains encrypted card data you should not store it. As the data was captured within the context of a client session you also need to submit it to us before the session has expired.<para />
        /// </summary>
        public string EncryptedCustomerInput { get; set; } = null;

        /// <summary>
        /// Object containing additional data that will be used to assess the risk of fraud<para />
        /// </summary>
        public FraudFields FraudFields { get; set; } = null;

        /// <summary>
        /// Use this field after a successful Hosted Tokenization session to create a payment with the tokenized payment method details.<para />
        /// </summary>
        public string HostedTokenizationId { get; set; } = null;

        /// <summary>
        /// Object containing the specific input details for mobile payments<para />
        /// </summary>
        public MobilePaymentMethodSpecificInput MobilePaymentMethodSpecificInput { get; set; } = null;

        /// <summary>
        /// Order object containing order related data <para />
        ///  Please note that this object is required to be able to submit the amount.<para />
        /// </summary>
        public Order Order { get; set; } = null;

        /// <summary>
        /// Object containing the specific input details for payments that involve redirects to 3rd parties to complete, like iDeal and PayPal<para />
        /// </summary>
        public RedirectPaymentMethodSpecificInput RedirectPaymentMethodSpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing the specific input details for SEPA direct debit payments<para />
        /// </summary>
        public SepaDirectDebitPaymentMethodSpecificInput SepaDirectDebitPaymentMethodSpecificInput { get; set; } = null;
    }
}

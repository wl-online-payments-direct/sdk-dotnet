/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePaymentRequest
    {
        /// <summary>
        /// Object containing the specific input details for card payments
        /// </summary>
        public CardPaymentMethodSpecificInput CardPaymentMethodSpecificInput { get; set; }

        /// <summary>
        /// Data that was encrypted client side containing all customer entered data elements like card data.
        /// Note: Because this data can only be submitted once to our system and contains encrypted card data you should not store it. As the data was captured within the context of a client session you also need to submit it to us before the session has expired.
        /// </summary>
        public string EncryptedCustomerInput { get; set; }

        /// <summary>
        /// This section will contain feedback Urls to provide feedback on the payment.
        /// </summary>
        public Feedbacks Feedbacks { get; set; }

        /// <summary>
        /// Object containing additional data that will be used to assess the risk of fraud
        /// </summary>
        public FraudFields FraudFields { get; set; }

        /// <summary>
        /// A unique identifier that references a previously created hosted fields session. Use this field to create a payment with the payment method details securely captured in the referenced hosted fields session.
        /// </summary>
        public string HostedFieldsSessionId { get; set; }

        /// <summary>
        /// Use this field after a successful Hosted Tokenization session to create a payment with the tokenized payment method details.
        /// </summary>
        public string HostedTokenizationId { get; set; }

        /// <summary>
        /// Object containing the specific input details for mobile payments
        /// </summary>
        public MobilePaymentMethodSpecificInput MobilePaymentMethodSpecificInput { get; set; }

        /// <summary>
        /// This object contains additional payment details for omnichannel merchants.
        /// </summary>
        public OmnichannelPaymentSpecificInput OmnichannelPaymentSpecificInput { get; set; }

        /// <summary>
        /// The order object contains order-related data;
        /// Please note that this object is required to submit the amount.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Object containing the specific input details for payments that involve redirects to 3rd parties to complete, like iDeal and PayPal
        /// </summary>
        public RedirectPaymentMethodSpecificInput RedirectPaymentMethodSpecificInput { get; set; }

        /// <summary>
        /// Object containing the specific input details for SEPA direct debit payments
        /// </summary>
        public SepaDirectDebitPaymentMethodSpecificInput SepaDirectDebitPaymentMethodSpecificInput { get; set; }
    }
}

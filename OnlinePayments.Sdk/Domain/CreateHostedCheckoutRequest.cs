/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateHostedCheckoutRequest
    {
        /// <summary>
        /// Object containing the specific input details for card payments
        /// </summary>
        public CardPaymentMethodSpecificInputBase CardPaymentMethodSpecificInput { get; set; }

        /// <summary>
        /// This section will contain feedback Urls to provide feedback on the payment.
        /// </summary>
        public Feedbacks Feedbacks { get; set; }

        /// <summary>
        /// Object containing additional data that will be used to assess the risk of fraud
        /// </summary>
        public FraudFields FraudFields { get; set; }

        /// <summary>
        /// Object containing hosted checkout specific data
        /// </summary>
        public HostedCheckoutSpecificInput HostedCheckoutSpecificInput { get; set; }

        /// <summary>
        /// Object containing the specific input details for mobile payments
        /// </summary>
        public MobilePaymentMethodHostedCheckoutSpecificInput MobilePaymentMethodSpecificInput { get; set; }

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
        public SepaDirectDebitPaymentMethodSpecificInputBase SepaDirectDebitPaymentMethodSpecificInput { get; set; }
    }
}

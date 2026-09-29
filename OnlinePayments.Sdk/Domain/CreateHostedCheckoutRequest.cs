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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedCheckoutRequest WithCardPaymentMethodSpecificInput(CardPaymentMethodSpecificInputBase value)
        {
            CardPaymentMethodSpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedCheckoutRequest WithFeedbacks(Feedbacks value)
        {
            Feedbacks = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedCheckoutRequest WithFraudFields(FraudFields value)
        {
            FraudFields = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedCheckoutRequest WithHostedCheckoutSpecificInput(HostedCheckoutSpecificInput value)
        {
            HostedCheckoutSpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedCheckoutRequest WithMobilePaymentMethodSpecificInput(MobilePaymentMethodHostedCheckoutSpecificInput value)
        {
            MobilePaymentMethodSpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedCheckoutRequest WithOrder(Order value)
        {
            Order = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedCheckoutRequest WithRedirectPaymentMethodSpecificInput(RedirectPaymentMethodSpecificInput value)
        {
            RedirectPaymentMethodSpecificInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CreateHostedCheckoutRequest WithSepaDirectDebitPaymentMethodSpecificInput(SepaDirectDebitPaymentMethodSpecificInputBase value)
        {
            SepaDirectDebitPaymentMethodSpecificInput = value;
            return this;
        }
    }
}

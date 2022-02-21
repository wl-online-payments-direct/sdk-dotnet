/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateHostedCheckoutRequest
    {
        /// <summary>
        /// Object containing the specific input details for card payments<para />
        /// </summary>
        public CardPaymentMethodSpecificInputBase CardPaymentMethodSpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing additional data that will be used to assess the risk of fraud<para />
        /// </summary>
        public FraudFields FraudFields { get; set; } = null;

        /// <summary>
        /// Object containing hosted checkout specific data<para />
        /// </summary>
        public HostedCheckoutSpecificInput HostedCheckoutSpecificInput { get; set; } = null;

        /// <summary>
        /// Object containing the specific input details for mobile payments<para />
        /// </summary>
        public MobilePaymentMethodHostedCheckoutSpecificInput MobilePaymentMethodSpecificInput { get; set; } = null;

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
        public SepaDirectDebitPaymentMethodSpecificInputBase SepaDirectDebitPaymentMethodSpecificInput { get; set; } = null;
    }
}

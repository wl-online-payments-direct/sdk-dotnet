/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePaymentLinkRequest
    {
        /// <summary>
        /// Object containing the specific input details for card payments<para />
        /// </summary>
        public CardPaymentMethodSpecificInputBase CardPaymentMethodSpecificInput { get; set; } = null;

        /// <summary>
        /// A note related to the created payment link.<para />
        /// <para />
        /// Deprecated: Use `paymentLinkSpecificInput/description` instead.<para />
        /// </summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// The date after which the payment link will not be usable to complete the payment. The date sent cannot be more than 6 months in the future or a past date. It must also contain the UTC offset.<para />
        /// <para />
        /// Deprecated: Use `paymentLinkSpecificInput/expirationDate` instead.<para />
        /// </summary>
        public string ExpirationDate { get; set; } = null;

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
        /// An object containing the details of the related payment input.<para />
        /// <para />
        /// Deprecated: All properties in `paymentLinkOrder` are deprecated.  <para />
        /// Use corresponding values as noted below:  <para />
        /// | Property | Replacement |<para />
        /// | - | - |<para />
        /// | merchantReference | `order/references/merchantReference` |  <para />
        /// | amount | `order/amountOfMoney` |  <para />
        /// | surchargeSpecificInput | `order/surchargeSpecificInput` |<para />
        /// </summary>
        public PaymentLinkOrderInput PaymentLinkOrder { get; set; } = null;

        /// <summary>
        /// An object containing details specific to payment link creation<para />
        /// </summary>
        public PaymentLinkSpecificInput PaymentLinkSpecificInput { get; set; } = null;

        /// <summary>
        /// The payment link recipient name.<para />
        /// <para />
        /// Deprecated: Use `paymentLinkSpecificInput/recipientName` instead.<para />
        /// </summary>
        public string RecipientName { get; set; } = null;

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

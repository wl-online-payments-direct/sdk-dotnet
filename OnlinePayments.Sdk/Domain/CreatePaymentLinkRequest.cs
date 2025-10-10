/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class CreatePaymentLinkRequest
    {
        /// <summary>
        /// Object containing the specific input details for card payments
        /// </summary>
        public CardPaymentMethodSpecificInputBase CardPaymentMethodSpecificInput { get; set; }

        /// <summary>
        /// A note related to the created payment link.
        /// <p />
        /// Deprecated: Use <c>paymentLinkSpecificInput/description</c> instead.
        /// </summary>
        [Obsolete("A note related to the created payment link.  Use paymentLinkSpecificInput/description instead.")]
        public string Description { get; set; }

        /// <summary>
        /// The date after which the payment link will not be usable to complete the payment. The date sent cannot be more than 6 months in the future or a past date. It must also contain the UTC offset.
        /// <p />
        /// Deprecated: Use <c>paymentLinkSpecificInput/expirationDate</c> instead.
        /// </summary>
        [Obsolete("The date after which the payment link will not be usable to complete the payment. The date sent cannot be more than 6 months in the future or a past date. It must also contain the UTC offset.  Use paymentLinkSpecificInput/expirationDate instead.")]
        public DateTimeOffset ExpirationDate { get; set; }

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
        /// Indicates if the payment link can be used multiple times. The default value for this property is false
        /// </summary>
        public bool? IsReusableLink { get; set; }

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
        /// An object containing the details of the related payment input.
        /// <p />
        /// Deprecated: All properties in <c>paymentLinkOrder</c> are deprecated.
        /// Use corresponding values as noted below:
        /// | Property | Replacement |
        /// | - | - |
        /// | merchantReference | <c>references/merchantReference</c> |
        /// | amount | <c>order/amountOfMoney</c> |
        /// | surchargeSpecificInput | <c>order/surchargeSpecificInput</c> |
        /// </summary>
        public PaymentLinkOrderInput PaymentLinkOrder { get; set; }

        /// <summary>
        /// An object containing details specific to payment link creation
        /// </summary>
        public PaymentLinkSpecificInput PaymentLinkSpecificInput { get; set; }

        /// <summary>
        /// The payment link recipient name.
        /// <p />
        /// Deprecated: Use <c>paymentLinkSpecificInput/recipientName</c> instead.
        /// </summary>
        [Obsolete("The payment link recipient name.  Use paymentLinkSpecificInput/recipientName instead.")]
        public string RecipientName { get; set; }

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

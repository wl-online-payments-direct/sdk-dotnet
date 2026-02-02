/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificInputBase
    {
        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - Default - Allows subsequent payments to use PSD2 dynamic linking from this payment (including Card On File).</description></item>
        ///   <item><description>false - Indicates that the dynamic linking (including Card On File data) will be ignored.</description></item>
        /// </list>
        /// </summary>
        public bool? AllowDynamicLinking { get; set; }

        /// <summary>
        /// Determines the type of the authorization that will be used. Allowed values:
        /// <list type="bullet">
        ///   <item><description>FINAL_AUTHORIZATION - The payment creation results in an authorization that is ready for capture. Final authorizations can't be reversed and need to be captured for the full amount within 7 days.</description></item>
        ///   <item><description>PRE_AUTHORIZATION - The payment creation results in a pre-authorization that is ready for capture. Pre-authortizations can be reversed and can be captured within 30 days. The capture amount can be lower than the authorized amount.</description></item>
        ///   <item><description>SALE - The payment creation results in an authorization that is already captured at the moment of approval.</description></item>
        /// </list>
        /// <p />
        /// Only used with some acquirers, ignored for acquirers that do not support this. In case the acquirer does not allow this to be specified the authorizationMode is 'unspecified', which behaves similar to a final authorization.
        /// </summary>
        public string AuthorizationMode { get; set; }

        /// <summary>
        /// Object containing specific input required for Dynamic Currency Conversion.
        /// </summary>
        public CurrencyConversionSpecificInput CurrencyConversionSpecificInput { get; set; }

        /// <summary>
        /// The unique scheme transactionId of the initial transaction that was performed with SCA. In case this is unknown a scheme transactionId of an earlier transaction part of the same sequence can be used as a fall-back. Strongly advised to be submitted for any MerchantInitiated or recurring transaction (a subsequent one).
        /// </summary>
        public string InitialSchemeTransactionId { get; set; }

        /// <summary>
        /// Object containing marketplace-related data for additional information on sub-merchants (retailers) transacting via the marketplace’s platform.
        /// This object is required for platforms onboarding multiple sellers to ensure accurate identification and attribution of each transaction.
        /// The platform must collect and submit the retailer’s country and regional information in accordance with card scheme requirements.
        /// In some cases, Visa may treat specific regions—such as EU member states—as a single country entity for regulatory and reporting purposes.
        /// </summary>
        public MarketPlace MarketPlace { get; set; }

        /// <summary>
        /// Container announcing forecoming subsequent payments. Holds modalities of these subsequent payments.
        /// </summary>
        public MultiplePaymentInformation MultiplePaymentInformation { get; set; }

        /// <summary>
        /// Object containing specific input required for CB payments
        /// </summary>
        public PaymentProduct130SpecificInput PaymentProduct130SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for bancontact.
        /// </summary>
        public PaymentProduct3012SpecificInput PaymentProduct3012SpecificInput { get; set; }

        /// <summary>
        /// An object containing specific input required for VISA purchasing authorization.
        /// </summary>
        public PaymentProduct3013SpecificInput PaymentProduct3013SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for OneyDuplo Leroy Merlin payments.
        /// </summary>
        public PaymentProduct3208SpecificInput PaymentProduct3208SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for OneyDuplo Alcampo payments.
        /// </summary>
        public PaymentProduct3209SpecificInput PaymentProduct3209SpecificInput { get; set; }

        /// <summary>
        /// Object containing specific input required for Cpay payments.
        /// </summary>
        public PaymentProduct5100SpecificInput PaymentProduct5100SpecificInput { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Object containing data related to recurring
        /// </summary>
        public CardRecurrenceDetails Recurring { get; set; }

        /// <summary>
        /// Object containing specific data regarding 3-D Secure
        /// </summary>
        public ThreeDSecureBase ThreeDSecure { get; set; }

        /// <summary>
        /// ID of the token to use to create the payment.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Indicates if this transaction should be tokenized * true - Tokenize the transaction. * false - Do not tokenize the transaction, unless it would be tokenized by other means such as auto-tokenization of recurring payments. Note: This property is deprecated for Hosted Checkout integrations. It has been deprecated by hostedCheckoutSpecificInput.cardPaymentMethodSpecificInput.tokenizationMode.
        /// </summary>
        public bool? Tokenize { get; set; }

        /// <summary>
        /// Indicates the channel via which the payment is created. Allowed values:
        /// <list type="bullet">
        ///   <item><description>ECOMMERCE - The transaction is a regular E-Commerce transaction.</description></item>
        ///   <item><description>MOTO - The transaction is a Mail Order/Telephone Order.</description></item>
        /// </list>
        /// <p />
        /// Defaults to ECOMMERCE.
        /// </summary>
        public string TransactionChannel { get; set; }

        /// <summary>
        /// Indicates which party initiated the unscheduled recurring transaction. Allowed values:
        /// <list type="bullet">
        ///   <item><description>merchantInitiated - Merchant Initiated Transaction.</description></item>
        ///   <item><description>cardholderInitiated - Cardholder Initiated Transaction.
        /// Note:</description></item>
        ///   <item><description>This property is not allowed if isRecurring is true.</description></item>
        ///   <item><description>When a customer has chosen to use a token on a hosted checkout this property is set to &quot;cardholderInitiated&quot;.</description></item>
        /// </list>
        /// </summary>
        public string UnscheduledCardOnFileRequestor { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>first = This transaction is the first of a series of unscheduled recurring transactions</description></item>
        ///   <item><description>subsequent = This transaction is a subsequent transaction in a series of unscheduled recurring transactions
        /// Note: this property is not allowed if isRecurring is true.</description></item>
        /// </list>
        /// </summary>
        public string UnscheduledCardOnFileSequenceIndicator { get; set; }
    }
}

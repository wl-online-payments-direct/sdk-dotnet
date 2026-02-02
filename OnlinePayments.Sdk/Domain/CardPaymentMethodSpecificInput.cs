/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificInput
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
        /// Object containing card details
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// The end date of the last scheduled payment in a series of transactions.
        /// Format YYYYMMDD
        /// </summary>
        public string CardOnFileRecurringExpiration { get; set; }

        /// <summary>
        /// Period of payment occurrence for recurring and installment payments. Allowed values:
        /// <list type="bullet">
        ///   <item><description>Yearly</description></item>
        ///   <item><description>Quarterly</description></item>
        ///   <item><description>Monthly</description></item>
        ///   <item><description>Weekly</description></item>
        ///   <item><description>Daily</description></item>
        /// </list>
        /// </summary>
        public string CardOnFileRecurringFrequency { get; set; }

        /// <summary>
        /// For cobranded cards, this field indicates the brand selection method:
        /// <list type="bullet">
        ///   <item><description>default - The holder implicitly accepted the default brand.</description></item>
        ///   <item><description>alternative - The holder explicitly selected an alternative brand.</description></item>
        ///   <item><description>notApplicable - The card is not cobranded.</description></item>
        /// </list>
        /// </summary>
        public string CobrandSelectionIndicator { get; set; }

        public CurrencyConversionInput CurrencyConversion { get; set; }

        /// <summary>
        /// The unique scheme transactionId of the initial transaction that was performed with SCA. In case this is unknown a scheme transactionId of an earlier transaction part of the same sequence can be used as a fall-back. Strongly advised to be submitted for any MerchantInitiated or recurring transaction (a subsequent one).
        /// </summary>
        public string InitialSchemeTransactionId { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true - Indicates that the transaction is part of a scheduled recurring sequence. In addition, recurringPaymentSequenceIndicator indicates if the transaction is the first or subsequent in a recurring sequence.</description></item>
        ///   <item><description>false - Indicates that the transaction is not part of a scheduled recurring sequence.
        /// The default value for this property is false.</description></item>
        /// </list>
        /// </summary>
        public bool? IsRecurring { get; set; }

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
        /// Object containing Network Token details
        /// </summary>
        public NetworkTokenData NetworkTokenData { get; set; }

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
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Object containing data related to recurring
        /// </summary>
        public CardRecurrenceDetails Recurring { get; set; }

        /// <summary>
        /// The URL that the customer is redirect to after the payment flow has finished. You can add any number of key value pairs in the query string that, for instance help you to identify the customer when they return to your site. Please note that we will also append some additional key value pairs that will also help you with this identification process.
        /// Note: The provided URL should be absolute and contain the protocol to use, e.g. http:// or https://. For use on mobile devices a custom protocol can be used in the form of protocol://. This protocol must be registered on the device first.
        /// URLs without a protocol will be rejected.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// This is the unique Scheme Reference Data from the initial transaction that was performed with a Strong Customer Authentication. In case this value is unknown, a Scheme Reference of an earlier transaction that was part of the same sequence can be used as a fall-back. Still, it is strongly advised to submit this value for any Merchant Initiated Transaction or any recurring transaction (hereby defined as &quot;Subsequent&quot;).
        /// </summary>
        public string SchemeReferenceData { get; set; }

        /// <summary>
        /// Deprecated: Use threeDSecure.skipAuthentication instead.
        /// <list type="bullet">
        ///   <item><description>true = 3D Secure authentication will be skipped for this transaction. This setting should be used when isRecurring is set to true and recurringPaymentSequenceIndicator is set to recurring.</description></item>
        ///   <item><description>false = 3D Secure authentication will not be skipped for this transaction.</description></item>
        /// </list>
        /// <p />
        /// Note: This is only possible if your account in our system is setup for 3D Secure authentication and if your configuration in our system allows you to override it per transaction.
        /// </summary>
        [Obsolete("Use threeDSecure.skipAuthentication instead.  * true = 3D Secure authentication will be skipped for this transaction. This setting should be used when isRecurring is set to true and recurringPaymentSequenceIndicator is set to recurring.  * false = 3D Secure authentication will not be skipped for this transaction.    Note: This is only possible if your account in our system is setup for 3D Secure authentication and if your configuration in our system allows you to override it per transaction.")]
        public bool? SkipAuthentication { get; set; }

        /// <summary>
        /// Object containing specific data regarding 3-D Secure
        /// </summary>
        public ThreeDSecure ThreeDSecure { get; set; }

        /// <summary>
        /// ID of the token to use to create the payment.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Indicates if this transaction should be tokenized
        /// <list type="bullet">
        ///   <item><description>true - Tokenize the transaction. Note that a payment on the payment platform that results in a status REDIRECTED cannot be tokenized in this way.</description></item>
        ///   <item><description>false - Do not tokenize the transaction, unless it would be tokenized by other means such as auto-tokenization of recurring payments.</description></item>
        /// </list>
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

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificOutput
    {
        /// <summary>
        /// This object contains the acceptance information for the card payment authorization.
        /// </summary>
        public Acceptance Acceptance { get; set; }

        /// <summary>
        /// Information about the acquirer used to process the transaction
        /// </summary>
        public AcquirerInformation AcquirerInformation { get; set; }

        /// <summary>
        /// The amount to be authenticated. This field should be populated if the amount to be authenticated differs from the amount to be authorized (by default they are considered equal). Amount in cents and always having 2 decimals.
        /// </summary>
        public long? AuthenticatedAmount { get; set; }

        /// <summary>
        /// Card Authorization code as returned by the acquirer
        /// </summary>
        public string AuthorisationCode { get; set; }

        /// <summary>
        /// Object containing card details
        /// </summary>
        public CardEssentials Card { get; set; }

        /// <summary>
        /// Information about whether the payment is made using Click to Pay
        /// </summary>
        public ClickToPay ClickToPay { get; set; }

        /// <summary>
        /// For cobranded cards, this field indicates the brand selection method:
        /// <list type="bullet">
        ///   <item><description>default - The holder implicitly accepted the default brand.</description></item>
        ///   <item><description>alternative - The holder explicitly selected an alternative brand.</description></item>
        ///   <item><description>notApplicable - The card is not cobranded.</description></item>
        /// </list>
        /// </summary>
        public string CobrandSelectionIndicator { get; set; }

        /// <summary>
        /// The CRM (Customer Relationship Management) token group. CRM tokens are available to enhance knowledge of a merchant's customers by attempting to identify the customer.
        /// </summary>
        public CrmToken CrmToken { get; set; }

        public CurrencyConversion CurrencyConversion { get; set; }

        public ExternalTokenLinked ExternalTokenLinked { get; set; }

        /// <summary>
        /// Fraud results contained in the CardFraudResults object
        /// </summary>
        public CardFraudResults FraudResults { get; set; }

        /// <summary>
        /// The unique scheme transactionId of the initial transaction that was performed with SCA. In case this is unknown a scheme transactionId of an earlier transaction part of the same sequence can be used as a fall-back. Strongly advised to be submitted for any MerchantInitiated or recurring transaction (a subsequent one).
        /// </summary>
        public string InitialSchemeTransactionId { get; set; }

        /// <summary>
        /// Object containing network token details
        /// </summary>
        public NetworkTokenEssentials NetworkTokenData { get; set; }

        /// <summary>
        /// The Payment Account Reference is a unique alphanumeric identifier that links a PAN with all subsequent PANs for the same payment account (e.g., following card replacement) and all EMV payment tokens associated with that account. On its own Payment Account Reference cannot be used to start financial transactions, but it does allow for complying with regulatory requirements, performing risk analysis &amp; supporting loyalty programs. Please note that the Payment Account Reference is a value returned after an authorization &amp; only if provided by the acquirer and/or the issuer.
        /// </summary>
        public string PaymentAccountReference { get; set; }

        /// <summary>
        /// The specific payment option for the payment. To be used as a complement of the more generic paymentProductId (oney, banquecasino, cofidis), which allows to define a variation of the selected paymentProductId (ex: facilypay3x, banquecasino4x, cofidis3x-sansfrais, ...). List of modalities included in the payment product page.
        /// </summary>
        public string PaymentOption { get; set; }

        /// <summary>
        /// OneyDuplo Leroy Merlin specific details
        /// </summary>
        public PaymentProduct3208SpecificOutput PaymentProduct3208SpecificOutput { get; set; }

        /// <summary>
        /// OneyDuplo Alcampo specific details
        /// </summary>
        public PaymentProduct3209SpecificOutput PaymentProduct3209SpecificOutput { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Provided only in case of declined authorization, for those acquirers that may respond with explicit instructions regarding potential reattempt processing.
        /// </summary>
        public ReattemptInstructions ReattemptInstructions { get; set; }

        /// <summary>
        /// This is the unique Scheme Reference Data from the initial transaction that was performed with a Strong Customer Authentication. In case this value is unknown, a Scheme Reference of an earlier transaction that was part of the same sequence can be used as a fall-back. Still, it is strongly advised to submit this value for any Merchant Initiated Transaction or any recurring transaction (hereby defined as &quot;Subsequent&quot;).
        /// </summary>
        public string SchemeReferenceData { get; set; }

        /// <summary>
        /// This is populated in case of a Mastercard payment, with the Mastercard TLID (Transaction Life Cycle ID) field.
        /// </summary>
        public string SchemeTransactionId { get; set; }

        /// <summary>
        /// 3D Secure results object
        /// </summary>
        public ThreeDSecureResults ThreeDSecureResults { get; set; }

        /// <summary>
        /// ID of the token. This property is populated when the payment was done with a token or when the payment was tokenized.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithAcceptance(Acceptance value)
        {
            Acceptance = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithAcquirerInformation(AcquirerInformation value)
        {
            AcquirerInformation = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithAuthenticatedAmount(long? value)
        {
            AuthenticatedAmount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithAuthorisationCode(string value)
        {
            AuthorisationCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithCard(CardEssentials value)
        {
            Card = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithClickToPay(ClickToPay value)
        {
            ClickToPay = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithCobrandSelectionIndicator(string value)
        {
            CobrandSelectionIndicator = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithCrmToken(CrmToken value)
        {
            CrmToken = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithCurrencyConversion(CurrencyConversion value)
        {
            CurrencyConversion = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithExternalTokenLinked(ExternalTokenLinked value)
        {
            ExternalTokenLinked = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithFraudResults(CardFraudResults value)
        {
            FraudResults = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithInitialSchemeTransactionId(string value)
        {
            InitialSchemeTransactionId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithNetworkTokenData(NetworkTokenEssentials value)
        {
            NetworkTokenData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithPaymentAccountReference(string value)
        {
            PaymentAccountReference = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithPaymentOption(string value)
        {
            PaymentOption = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithPaymentProduct3208SpecificOutput(PaymentProduct3208SpecificOutput value)
        {
            PaymentProduct3208SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithPaymentProduct3209SpecificOutput(PaymentProduct3209SpecificOutput value)
        {
            PaymentProduct3209SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithReattemptInstructions(ReattemptInstructions value)
        {
            ReattemptInstructions = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithSchemeReferenceData(string value)
        {
            SchemeReferenceData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithSchemeTransactionId(string value)
        {
            SchemeTransactionId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithThreeDSecureResults(ThreeDSecureResults value)
        {
            ThreeDSecureResults = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CardPaymentMethodSpecificOutput WithToken(string value)
        {
            Token = value;
            return this;
        }
    }
}

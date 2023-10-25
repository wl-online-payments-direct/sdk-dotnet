/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificOutput
    {
        /// <summary>
        /// Information about the acquirer used to process the transaction<para />
        /// </summary>
        public AcquirerInformation AcquirerInformation { get; set; } = null;

        /// <summary>
        /// Allows amount to be authenticated to be different from amount authorized. (Amount in cents and always having 2 decimals)<para />
        /// </summary>
        public long? AuthenticatedAmount { get; set; } = null;

        /// <summary>
        /// Card Authorization code as returned by the acquirer<para />
        /// </summary>
        public string AuthorisationCode { get; set; } = null;

        /// <summary>
        /// Object containing card details<para />
        /// </summary>
        public CardEssentials Card { get; set; } = null;

        public CurrencyConversion CurrencyConversion { get; set; } = null;

        public ExternalTokenLinked ExternalTokenLinked { get; set; } = null;

        /// <summary>
        /// Fraud results contained in the CardFraudResults object<para />
        /// </summary>
        public CardFraudResults FraudResults { get; set; } = null;

        /// <summary>
        /// The unique scheme transactionId of the initial transaction that was performed with SCA. In case this is unknown a scheme transactionId of an earlier transaction part of the same sequence can be used as a fall-back. Strongly advised to be submitted for any MerchantInitiated or recurring transaction (a subsequent one).<para />
        /// </summary>
        public string InitialSchemeTransactionId { get; set; } = null;

        /// <summary>
        /// The Payment Account Reference is a unique alphanumeric identifier that links a PAN with all subsequent PANs for the same payment account (e.g., following card replacement) and all EMV payment tokens associated with that account. On its own Payment Account Reference cannot be used to start financial transactions, but it does allow for complying with regulatory requirements, performing risk analysis & supporting loyalty programs. Please note that the Payment Account Reference is a value returned after an authorization & only if provided by the acquirer and/or the issuer.<para />
        /// </summary>
        public string PaymentAccountReference { get; set; } = null;

        /// <summary>
        /// The specific payment option for the payment. To be used as a complement of the more generic paymentProductId (oney, banquecasino, cofidis), which allows to define a variation of the selected paymentProductId (ex: facilypay3x, banquecasino4x, cofidis3x-sansfrais, ...). List of modalities included in the payment product page.<para />
        /// </summary>
        public string PaymentOption { get; set; } = null;

        /// <summary>
        /// OneyDuplo Leroy Merlin specific details<para />
        /// </summary>
        public PaymentProduct3208SpecificOutput PaymentProduct3208SpecificOutput { get; set; } = null;

        /// <summary>
        /// OneyDuplo Alcampo specific details<para />
        /// </summary>
        public PaymentProduct3209SpecificOutput PaymentProduct3209SpecificOutput { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;

        /// <summary>
        /// This is the unique Scheme Reference Data from the initial transaction that was performed with a Strong Customer Authentication. In case this value is unknown, a Scheme Reference of an earlier transaction that was part of the same sequence can be used as a fall-back. Still, it is strongly advised to submit this value for any Merchant Initiated Transaction or any recurring transaction (hereby defined as "Subsequent").<para />
        /// </summary>
        public string SchemeReferenceData { get; set; } = null;

        /// <summary>
        /// 3D Secure results object<para />
        /// </summary>
        public ThreeDSecureResults ThreeDSecureResults { get; set; } = null;

        /// <summary>
        /// ID of the token. This property is populated when the payment was done with a token or when the payment was tokenized.<para />
        /// </summary>
        public string Token { get; set; } = null;
    }
}

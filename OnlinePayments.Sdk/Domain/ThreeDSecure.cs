/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ThreeDSecure
    {
        /// <summary>
        /// The amount to be authenticated. This field should be populated if the amount to be authenticated differs from the amount to be authorized (by default they are considered equal). Amount in cents and always having 2 decimals.
        /// </summary>
        public long? AuthenticationAmount { get; set; }

        /// <summary>
        /// Dimensions of the challenge window that potentially will be displayed to the customer. The challenge content is formatted to appropriately render in this window to provide the best possible user experience. Preconfigured sizes are width x height in pixels of the window displayed in the customer browser window. Possible values are
        /// <list type="bullet">
        ///   <item><description>250x400 (default)</description></item>
        ///   <item><description>390x400</description></item>
        ///   <item><description>500x600</description></item>
        ///   <item><description>600x400</description></item>
        ///   <item><description>full-screen</description></item>
        /// </list>
        /// </summary>
        public string ChallengeCanvasSize { get; set; }

        /// <summary>
        /// Allows you to indicate if you want the customer to be challenged for extra security on this transaction. Possible values:
        /// <list type="bullet">
        ///   <item><description>no-preference - You have no preference whether or not to challenge the customer (default)</description></item>
        ///   <item><description>no-challenge-requested - you prefer the cardholder not to be challenged</description></item>
        ///   <item><description>challenge-requested - you prefer the customer to be challenged</description></item>
        ///   <item><description>challenge-required - you require the customer to be challenged</description></item>
        ///   <item><description>no-challenge-requested-risk-analysis-performed – letting the issuer know that you have already assessed the transaction with fraud prevention tool</description></item>
        ///   <item><description>no-challenge-requested-data-share-only – sharing data only with the DS</description></item>
        ///   <item><description>no-challenge-requested-consumer-authentication-performed – authentication already happened at your side – when login in to your website</description></item>
        ///   <item><description>no-challenge-requested-use-whitelist-exemption – cardholder has whitelisted you at with the issuer</description></item>
        ///   <item><description>challenge-requested-whitelist-prompt-requested – cardholder is trying to whitelist you</description></item>
        ///   <item><description>request-scoring-without-connecting-to-acs – sending information to CB DS for a fraud scoring</description></item>
        /// </list>
        /// </summary>
        public string ChallengeIndicator { get; set; }

        /// <summary>
        /// Determines whether the call is coming from an application or from a browser * AppBased - Call is coming from an application. * Browser - Call is coming from a browser
        /// </summary>
        public string DeviceChannel { get; set; }

        /// <summary>
        /// In PSD2, the ExemptionRequest field is used by merchants requesting an exemption when not using authentication on a transaction, in order to keep the conversion up.
        /// <list type="bullet">
        ///   <item><description>none = No exemption requested</description></item>
        ///   <item><description>transaction-risk-analysis = Fraud analysis has been done already by your own fraud module and transaction scored as low risk</description></item>
        ///   <item><description>low-value = Bellow 30 euros</description></item>
        ///   <item><description>whitelist = The cardholder has whitelisted you with their issuer</description></item>
        /// </list>
        /// </summary>
        public string ExemptionRequest { get; set; }

        /// <summary>
        /// Object containing 3D secure details.
        /// </summary>
        public ExternalCardholderAuthenticationData ExternalCardholderAuthenticationData { get; set; }

        /// <summary>
        /// The merchant fraud rate in the EEA is calculated as the total EEA card fraud divided by all EEA card volumes, as per PSD2 RTS. Mastercard will not calculate or validate the merchant fraud score.
        /// Accepted values are:
        /// <list type="bullet">
        ///   <item><description>1 - represents a fraud rate less than or equal to 1 basis point (bp), which is 0.01%.</description></item>
        ///   <item><description>2 - represents a fraud rate between 1 bp and 6 bps.</description></item>
        ///   <item><description>3 - represents a fraud rate between 6 bps and 13 bps.</description></item>
        ///   <item><description>4 - represents a fraud rate between 13 bps and 25 bps.</description></item>
        ///   <item><description>5 - represents a fraud rate greater than 25 bps.</description></item>
        /// </list>
        /// </summary>
        public int? MerchantFraudRate { get; set; }

        /// <summary>
        /// Object containing data regarding the customer authentication that occurred prior to the current transaction
        /// </summary>
        public ThreeDSecureData PriorThreeDSecureData { get; set; }

        /// <summary>
        /// Object containing browser specific redirection related data
        /// </summary>
        public RedirectionData RedirectionData { get; set; }

        /// <summary>
        /// Indicates that dedicated payment processes and procedures were used. A potential secure corporate payment exemption applies. Logically, this field should only be set to 'yes' if the acquirer exemption field is blank. A merchant cannot claim both acquirer exemption and secure payment. However, the DS will not validate the conditions in the extension; DS will pass data as presented.
        /// </summary>
        public bool? SecureCorporatePayment { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true = 3D Secure authentication will be skipped for this transaction. This setting should be used when isRecurring is set to true and recurringPaymentSequenceIndicator is set to &quot;recurring&quot;</description></item>
        ///   <item><description>false = 3D Secure authentication will not be skipped for this transaction</description></item>
        /// </list>
        /// <p />
        /// Note: This is only possible if your account in our system is setup for 3D Secure authentication and if your configuration in our system allows you to override it per transaction
        /// </summary>
        public bool? SkipAuthentication { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true = Soft Decline retry mechanism will be skipped for this transaction. The transaction will result in &quot;Authorization Declined&quot; status. This setting should be used when skipAuthentication is set to true and the merchant does not want to use Soft Decline retry mechanism.</description></item>
        ///   <item><description>false = Soft Decline retry mechanism will not be skipped for this transaction.</description></item>
        /// </list>
        /// <p />
        /// Note: skipSoftDecline defaults to false if empty. This is only possible if your account in our system is setup for 3D Secure authentication and if your configuration in our system allows you to override it per transaction.
        /// </summary>
        public bool? SkipSoftDecline { get; set; }
    }
}

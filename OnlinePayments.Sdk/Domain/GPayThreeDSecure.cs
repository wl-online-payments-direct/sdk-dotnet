/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GPayThreeDSecure
    {
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
        ///   <item><description>no-challenge-requested-risk-analysis-performed â€“ letting the issuer know that you have already assessed the transaction with fraud prevention tool</description></item>
        ///   <item><description>no-challenge-requested-data-share-only â€“ sharing data only with the DS</description></item>
        ///   <item><description>no-challenge-requested-consumer-authentication-performed â€“ authentication already happened at your side â€“ when login in to your website</description></item>
        ///   <item><description>no-challenge-requested-use-whitelist-exemption â€“ cardholder has whitelisted you at with the issuer</description></item>
        ///   <item><description>challenge-requested-whitelist-prompt-requested â€“ cardholder is trying to whitelist you</description></item>
        ///   <item><description>request-scoring-without-connecting-to-acs â€“ sending information to CB DS for a fraud scoring</description></item>
        /// </list>
        /// </summary>
        public string ChallengeIndicator { get; set; }

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
        /// Object containing browser specific redirection related data
        /// </summary>
        public RedirectionData RedirectionData { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true = 3D Secure authentication will be skipped for this transaction. This setting should be used when isRecurring is set to true and recurringPaymentSequenceIndicator is set to &quot;recurring&quot;</description></item>
        ///   <item><description>false = 3D Secure authentication will not be skipped for this transaction</description></item>
        /// </list>
        /// <p />
        /// Note: This is only possible if your account in our system is setup for 3D Secure authentication and if your configuration in our system allows you to override it per transaction
        /// </summary>
        public bool? SkipAuthentication { get; set; }
    }
}

/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ThreeDSecureBase
    {
        /// <summary>
        /// Dimensions of the challenge window that potentially will be displayed to the customer. The challenge content is formatted to appropriately render in this window to provide the best possible user experience. Preconfigured sizes are width x height in pixels of the window displayed in the customer browser window. Possible values are<para />
        ///    * 250x400 (default)<para />
        ///    * 390x400<para />
        ///    * 500x600<para />
        ///    * 600x400<para />
        ///    * full-screen<para />
        /// </summary>
        public string ChallengeCanvasSize { get; set; } = null;

        /// <summary>
        /// Allows you to indicate if you want the customer to be challenged for extra security on this transaction. Possible values:<para />
        ///  * no-preference - You have no preference whether or not to challenge the customer (default)<para />
        ///  * no-challenge-requested - you prefer the cardholder not to be challenged<para />
        ///  * challenge-requested - you prefer the customer to be challenged<para />
        ///  * challenge-required - you require the customer to be challenged<para />
        ///  * no-challenge-requested-risk-analysis-performed – letting the issuer know that you have already assessed the transaction with fraud prevention tool <para />
        ///  * no-challenge-requested-data-share-only – sharing data only with the DS<para />
        ///  * no-challenge-requested-consumer-authentication-performed – authentication already happened at your side – when login in to your website<para />
        ///  * no-challenge-requested-use-whitelist-exemption – cardholder has whitelisted you at with the issuer<para />
        ///  * challenge-requested-whitelist-prompt-requested – cardholder is trying to whitelist you<para />
        ///  * request-scoring-without-connecting-to-acs – sending information to CB DS for a fraud scoring<para />
        /// </summary>
        public string ChallengeIndicator { get; set; } = null;

        /// <summary>
        /// In PSD2, the ExemptionRequest field is used by merchants requesting an exemption when not using authentication on a transaction, in order to keep the conversion up.<para />
        /// * none = No exemption requested<para />
        /// * transaction-risk-analysis = Fraud analysis has been done already by your own fraud module and transaction scored as low risk<para />
        /// * low-value = Bellow 30 euros<para />
        /// * whitelist = The cardholder has whitelisted you with their issuer<para />
        /// </summary>
        public string ExemptionRequest { get; set; } = null;

        /// <summary>
        /// Merchant fraud rate in the EEA (all EEA card fraud divided by all EEA card volumes) calculated as per PSD2 RTS. Mastercard will not calculate or validate the merchant fraud score<para />
        /// Values accepted :<para />
        /// * 1 - represents fraud rate less than or equal to 1 basis point [bp], which is 0.01%<para />
        /// * 2 - represents fraud rate between 1 bp + - and 6 bps<para />
        /// * 3 - represents fraud rate between 6 bps + - and 13 bps<para />
        /// * 4 - represents fraud rate between 13 bps + - and 25 bps<para />
        /// * 5 - represents fraud rate greater than 25 bps<para />
        /// </summary>
        public int? MerchantFraudRate { get; set; } = null;

        /// <summary>
        /// Object containing data regarding the customer authentication that occurred prior to the current transaction<para />
        /// </summary>
        public ThreeDSecureData PriorThreeDSecureData { get; set; } = null;

        /// <summary>
        /// Indicates dedicated payment processes and procedures were used, potential secure corporate payment exemption applies Logically this field should only be set to yes if the <para />
        /// acquirer exemption field is blank. A merchant cannot claim both acquirer exemption and  secure payment. However, the DS will not validate <para />
        /// the conditions in the extension. DS will pass data as presented.<para />
        /// </summary>
        public bool? SecureCorporatePayment { get; set; } = null;

        /// <summary>
        /// * true = 3D Secure authentication will be skipped for this transaction. This setting should be used when isRecurring is set to true and recurringPaymentSequenceIndicator is set to "recurring"<para />
        /// * false = 3D Secure authentication will not be skipped for this transaction<para />
        /// <para />
        /// Note: This is only possible if your account in our system is setup for 3D Secure authentication and if your configuration in our system allows you to override it per transaction<para />
        /// </summary>
        public bool? SkipAuthentication { get; set; } = null;

        /// <summary>
        /// * true = Soft Decline retry mechanism will be skipped for this transaction. The transaction will result in "Authorization Declined" status. This setting should be used when skipAuthentication is set to true and the merchant does not want to use Soft Decline retry mechanism.<para />
        /// * false = Soft Decline retry mechanism will not be skipped for this transaction.<para />
        /// <para />
        /// Note: skipSoftDecline defaults to false if empty. This is only possible if your account in our system is setup for 3D Secure authentication and if your configuration in our system allows you to override it per transaction.<para />
        /// </summary>
        public bool? SkipSoftDecline { get; set; } = null;
    }
}

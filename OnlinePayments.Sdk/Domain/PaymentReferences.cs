/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentReferences
    {
        /// <summary>
        /// It allows you to store additional parameters for the transaction in the format you prefer (e.g.-> key-value query string, JSON, etc.) These parameters are then echoed back to you in API GET calls and Webhook notifications. This field must not contain any personal data.<para />
        /// </summary>
        public string MerchantParameters { get; set; } = null;

        /// <summary>
        /// Your unique reference of the transaction that is also returned in our report files. This is almost always used for your reconciliation of our report files.<para />
        /// It is highly recommended to provide a single MerchantReference per unique order on your side<para />
        /// </summary>
        public string MerchantReference { get; set; } = null;
    }
}

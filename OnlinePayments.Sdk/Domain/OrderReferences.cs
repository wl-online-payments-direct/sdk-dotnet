/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OrderReferences
    {
        /// <summary>
        /// Descriptive text that is used towards to customer, either during an online checkout at a third party and/or on the statement of the customer. For card transactions this is usually referred to as a Soft Descriptor. The maximum allowed length varies per card acquirer:<para />
        ///  * AIB - 22 characters<para />
        ///  * American Express - 25 characters<para />
        ///  * Atos Origin BNP - 15 characters<para />
        ///  * Barclays - 25 characters<para />
        ///  * Catella - 22 characters<para />
        ///  * CBA - 20 characters<para />
        ///  * Elavon - 25 characters<para />
        ///  * First Data - 25 characters<para />
        ///  * INICIS (INIPAY) - 22-30 characters<para />
        ///  * JCB - 25 characters<para />
        ///  * Merchant Solutions - 22-25 characters<para />
        ///  * Payvision (EU & HK) - 25 characters<para />
        ///  * SEB Euroline - 22 characters<para />
        ///  * Sub1 Argentina - 15 characters<para />
        ///  * Wells Fargo - 25 characters<para />
        /// <para />
        /// Note that we advise you to use 22 characters as the max length as beyond this our experience is that issuers will start to truncate. We currently also only allow per API call overrides for AIB and Barclays<para />
        /// For alternative payment products the maximum allowed length varies per payment product:<para />
        ///  * 402 e-Przelewy - 30 characters<para />
        ///  * 404 INICIS - 80 characters<para />
        ///  * 802 Nordea ePayment Finland - 234 characters<para />
        ///  * 809 iDeal - 32 characters<para />
        ///  * 836 SOFORT - 42 characters<para />
        ///  * 840 PayPal - 127 characters<para />
        ///  * 841 WebMoney - 175 characters<para />
        ///  * 849 Yandex - 64 characters<para />
        ///  * 861 Alipay - 256 characters<para />
        ///  * 863 WeChat Pay - 32 characters<para />
        ///  * 880 BOKU - 20 characters<para />
        ///  * 8580 Qiwi - 255 characters<para />
        ///  * 1504 Konbini - 80 characters<para />
        /// <para />
        /// All other payment products do not support a descriptor.<para />
        /// </summary>
        public string Descriptor { get; set; } = null;

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

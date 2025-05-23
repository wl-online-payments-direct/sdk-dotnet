/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePayoutRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Object containing the payout details for a card
        /// </summary>
        public CardPayoutMethodSpecificInput CardPayoutMethodSpecificInput { get; set; }

        /// <summary>
        /// Descriptive text that is used towards to customer, either during an online checkout at a third party and/or on the statement of the customer. For card transactions this is usually referred to as a Soft Descriptor. The maximum allowed length varies per card acquirer:
        /// <list type="bullet">
        ///   <item><description>AIB - 22 characters</description></item>
        ///   <item><description>American Express - 25 characters</description></item>
        ///   <item><description>Atos Origin BNP - 15 characters</description></item>
        ///   <item><description>Barclays - 25 characters</description></item>
        ///   <item><description>Catella - 22 characters</description></item>
        ///   <item><description>CBA - 20 characters</description></item>
        ///   <item><description>Elavon - 25 characters</description></item>
        ///   <item><description>First Data - 25 characters</description></item>
        ///   <item><description>INICIS (INIPAY) - 22-30 characters</description></item>
        ///   <item><description>JCB - 25 characters</description></item>
        ///   <item><description>Merchant Solutions - 22-25 characters</description></item>
        ///   <item><description>Payvision (EU &amp; HK) - 25 characters</description></item>
        ///   <item><description>SEB Euroline - 22 characters</description></item>
        ///   <item><description>Sub1 Argentina - 15 characters</description></item>
        ///   <item><description>Wells Fargo - 25 characters
        /// Note that we advise you to use 22 characters as the max length as beyond this our experience is that issuers will start to truncate. We currently also only allow per API call overrides for AIB and Barclays
        /// For alternative payment products the maximum allowed length varies per payment product:</description></item>
        ///   <item><description>402 e-Przelewy - 30 characters</description></item>
        ///   <item><description>404 INICIS - 80 characters</description></item>
        ///   <item><description>802 Nordea ePayment Finland - 234 characters</description></item>
        ///   <item><description>809 iDeal - 32 characters</description></item>
        ///   <item><description>836 SOFORT - 42 characters</description></item>
        ///   <item><description>840 PayPal - 127 characters</description></item>
        ///   <item><description>841 WebMoney - 175 characters</description></item>
        ///   <item><description>849 Yandex - 64 characters</description></item>
        ///   <item><description>861 Alipay - 256 characters</description></item>
        ///   <item><description>863 WeChat Pay - 32 characters</description></item>
        ///   <item><description>880 BOKU - 20 characters</description></item>
        ///   <item><description>8580 Qiwi - 255 characters</description></item>
        ///   <item><description>1504 Konbini - 80 characters
        /// All other payment products do not support a descriptor.</description></item>
        /// </list>
        /// </summary>
        public string Descriptor { get; set; }

        /// <summary>
        /// This section will contain feedback Urls to provide feedback on the payment.
        /// </summary>
        public Feedbacks Feedbacks { get; set; }

        /// <summary>
        /// Object containing the additional payout details for a Omnichannel merchants
        /// </summary>
        public OmnichannelPayoutSpecificInput OmnichannelPayoutSpecificInput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }
    }
}

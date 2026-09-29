/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct3013SpecificInput
    {
        /// <summary>
        /// An identifier that refers to the public tender
        /// </summary>
        public string MarketNumber { get; set; }

        /// <summary>
        /// An identifier allocated by the government
        /// </summary>
        public string PurchasingBuyerReference1 { get; set; }

        /// <summary>
        /// An identifier allocated by the government
        /// </summary>
        public string PurchasingBuyerReference2 { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3013SpecificInput WithMarketNumber(string value)
        {
            MarketNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3013SpecificInput WithPurchasingBuyerReference1(string value)
        {
            PurchasingBuyerReference1 = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3013SpecificInput WithPurchasingBuyerReference2(string value)
        {
            PurchasingBuyerReference2 = value;
            return this;
        }
    }
}

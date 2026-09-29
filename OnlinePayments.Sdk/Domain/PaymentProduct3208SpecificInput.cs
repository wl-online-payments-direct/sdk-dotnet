/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct3208SpecificInput
    {
        /// <summary>
        /// This field indicates the finance code provided by the merchant after the buyer has selected the proper financing option.
        /// </summary>
        public string MerchantFinanceCode { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProduct3208SpecificInput WithMerchantFinanceCode(string value)
        {
            MerchantFinanceCode = value;
            return this;
        }
    }
}

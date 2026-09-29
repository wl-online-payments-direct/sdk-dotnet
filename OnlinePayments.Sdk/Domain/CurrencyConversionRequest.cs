/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversionRequest
    {
        public DccCardSource CardSource { get; set; }

        public Transaction Transaction { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CurrencyConversionRequest WithCardSource(DccCardSource value)
        {
            CardSource = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CurrencyConversionRequest WithTransaction(Transaction value)
        {
            Transaction = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundCardMethodSpecificOutput
    {
        public CurrencyConversion CurrencyConversion { get; set; }

        public long? TotalAmountPaid { get; set; }

        public long? TotalAmountRefunded { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithCurrencyConversion(CurrencyConversion value)
        {
            CurrencyConversion = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithTotalAmountPaid(long? value)
        {
            TotalAmountPaid = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithTotalAmountRefunded(long? value)
        {
            TotalAmountRefunded = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundRedirectMethodSpecificOutput
    {
        public long? TotalAmountPaid { get; set; }

        public long? TotalAmountRefunded { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRedirectMethodSpecificOutput WithTotalAmountPaid(long? value)
        {
            TotalAmountPaid = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRedirectMethodSpecificOutput WithTotalAmountRefunded(long? value)
        {
            TotalAmountRefunded = value;
            return this;
        }
    }
}

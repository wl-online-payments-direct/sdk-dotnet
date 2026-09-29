/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundEWalletMethodSpecificOutput
    {
        public RefundPaymentProduct840SpecificOutput PaymentProduct840SpecificOutput { get; set; }

        public long? TotalAmountPaid { get; set; }

        public long? TotalAmountRefunded { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundEWalletMethodSpecificOutput WithPaymentProduct840SpecificOutput(RefundPaymentProduct840SpecificOutput value)
        {
            PaymentProduct840SpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundEWalletMethodSpecificOutput WithTotalAmountPaid(long? value)
        {
            TotalAmountPaid = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundEWalletMethodSpecificOutput WithTotalAmountRefunded(long? value)
        {
            TotalAmountRefunded = value;
            return this;
        }
    }
}

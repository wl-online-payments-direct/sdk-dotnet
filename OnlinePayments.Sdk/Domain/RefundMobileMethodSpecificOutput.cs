/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundMobileMethodSpecificOutput
    {
        /// <summary>
        /// The card network that was used for a mobile payment method operation
        /// </summary>
        public string Network { get; set; }

        public long? TotalAmountPaid { get; set; }

        public long? TotalAmountRefunded { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundMobileMethodSpecificOutput WithNetwork(string value)
        {
            Network = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundMobileMethodSpecificOutput WithTotalAmountPaid(long? value)
        {
            TotalAmountPaid = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundMobileMethodSpecificOutput WithTotalAmountRefunded(long? value)
        {
            TotalAmountRefunded = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundRedirectPaymentMethodSpecificInput
    {
        /// <summary>
        /// Object containing specific input required for Wero refunds (Payment product ID 900).
        /// </summary>
        public RefundRedirectPaymentProduct900SpecificInput RefundRedirectPaymentProduct900SpecificInput { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundRedirectPaymentMethodSpecificInput WithRefundRedirectPaymentProduct900SpecificInput(RefundRedirectPaymentProduct900SpecificInput value)
        {
            RefundRedirectPaymentProduct900SpecificInput = value;
            return this;
        }
    }
}

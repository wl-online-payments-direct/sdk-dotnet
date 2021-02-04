/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class RefundPaymentProduct840CustomerAccount
    {
        public string CustomerAccountStatus { get; set; } = null;

        public string CustomerAddressStatus { get; set; } = null;

        /// <summary>
        /// The unique identifier of a PayPal account and will never change in the life cycle of a PayPal account<para />
        /// </summary>
        public string PayerId { get; set; } = null;
    }
}

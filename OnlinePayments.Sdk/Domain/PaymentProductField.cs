/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductField
    {
        /// <summary>
        /// Object containing data restrictions that apply to this field, like minimum and/or maximum length<para />
        /// </summary>
        public PaymentProductFieldDataRestrictions DataRestrictions { get; set; } = null;

        /// <summary>
        /// Object containing display hints for this field, like the order, mask, preferred keyboard<para />
        /// </summary>
        public PaymentProductFieldDisplayHints DisplayHints { get; set; } = null;

        public string Id { get; set; } = null;

        public string Type { get; set; } = null;
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductField
    {
        /// <summary>
        /// Object containing data restrictions that apply to this field, like minimum and/or maximum length
        /// </summary>
        public PaymentProductFieldDataRestrictions DataRestrictions { get; set; }

        /// <summary>
        /// Object containing display hints for this field, like the order, mask, preferred keyboard
        /// </summary>
        public PaymentProductFieldDisplayHints DisplayHints { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }
    }
}

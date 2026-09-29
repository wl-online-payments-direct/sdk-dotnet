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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductField WithDataRestrictions(PaymentProductFieldDataRestrictions value)
        {
            DataRestrictions = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductField WithDisplayHints(PaymentProductFieldDisplayHints value)
        {
            DisplayHints = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductField WithId(string value)
        {
            Id = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductField WithType(string value)
        {
            Type = value;
            return this;
        }
    }
}

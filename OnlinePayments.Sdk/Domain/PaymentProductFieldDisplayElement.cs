/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFieldDisplayElement
    {
        /// <summary>
        /// The ID of the display element.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The label of the display element.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The type of the display element. Indicates how the value should be presented. Possible values are:
        /// <list type="bullet">
        ///   <item><description>STRING - as plain text</description></item>
        ///   <item><description>CURRENCY - as an amount in cents displayed with a decimal separator and the currency of the payment</description></item>
        ///   <item><description>PERCENTAGE - as a number with a percentage sign</description></item>
        ///   <item><description>INTEGER - as an integer</description></item>
        ///   <item><description>URI - as a link</description></item>
        /// </list>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// the value of the display element.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldDisplayElement WithId(string value)
        {
            Id = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldDisplayElement WithLabel(string value)
        {
            Label = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldDisplayElement WithType(string value)
        {
            Type = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldDisplayElement WithValue(string value)
        {
            Value = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RangeValidator
    {
        public int? MaxValue { get; set; }

        public int? MinValue { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RangeValidator WithMaxValue(int? value)
        {
            MaxValue = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RangeValidator WithMinValue(int? value)
        {
            MinValue = value;
            return this;
        }
    }
}

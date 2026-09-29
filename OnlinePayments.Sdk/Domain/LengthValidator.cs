/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class LengthValidator
    {
        public int? MaxLength { get; set; }

        public int? MinLength { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LengthValidator WithMaxLength(int? value)
        {
            MaxLength = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LengthValidator WithMinLength(int? value)
        {
            MinLength = value;
            return this;
        }
    }
}

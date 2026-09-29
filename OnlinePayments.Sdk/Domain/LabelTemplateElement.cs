/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class LabelTemplateElement
    {
        /// <summary>
        /// Name of the attribute that is shown to the customer on selection pages or screens
        /// </summary>
        public string AttributeKey { get; set; }

        /// <summary>
        /// Regular mask for the attributeKey
        /// Note: The mask is optional as not every field has a mask
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LabelTemplateElement WithAttributeKey(string value)
        {
            AttributeKey = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LabelTemplateElement WithMask(string value)
        {
            Mask = value;
            return this;
        }
    }
}

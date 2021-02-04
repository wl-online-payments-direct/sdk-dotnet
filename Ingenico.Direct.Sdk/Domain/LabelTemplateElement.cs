/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class LabelTemplateElement
    {
        /// <summary>
        /// Name of the attribute that is shown to the customer on selection pages or screens<para />
        /// </summary>
        public string AttributeKey { get; set; } = null;

        /// <summary>
        /// Regular mask for the attributeKey<para />
        /// Note: The mask is optional as not every field has a mask<para />
        /// </summary>
        public string Mask { get; set; } = null;
    }
}

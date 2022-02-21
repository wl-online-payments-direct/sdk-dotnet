/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class AccountOnFileDisplayHints
    {
        /// <summary>
        /// Array of attribute keys and their mask<para />
        /// </summary>
        public IList<LabelTemplateElement> LabelTemplate { get; set; } = null;

        /// <summary>
        /// Partial URL that you can reference for the image of this payment product. You can use our server-side resize functionality by appending '?size={{width}}x{{height}}' to the full URL, where width and height are specified in pixels. The resized image will always keep its correct aspect ratio.<para />
        /// </summary>
        public string Logo { get; set; } = null;
    }
}

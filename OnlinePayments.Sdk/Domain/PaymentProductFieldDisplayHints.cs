/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFieldDisplayHints
    {
        /// <summary>
        /// * true - Indicates that this field is advised to be captured to increase the success rates even-though it isn't marked as required. Please note that making the field required could hurt the success rates negatively. This boolean only indicates our advise to always show this field to the customer.<para />
        /// * false - Indicates that this field is not to be shown unless it is a required field.<para />
        /// </summary>
        public bool? AlwaysShow { get; set; } = null;

        /// <summary>
        /// The order in which the fields should be shown (ascending)<para />
        /// </summary>
        public int? DisplayOrder { get; set; } = null;

        /// <summary>
        /// Object detailing the type of form element that should be used to present the field<para />
        /// </summary>
        public PaymentProductFieldFormElement FormElement { get; set; } = null;

        /// <summary>
        /// Label/Name of the field to be used in the user interface<para />
        /// </summary>
        public string Label { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// Link that should be used to replace the '{link}' variable in the label.<para />
        /// </summary>
        public string Link { get; set; } = null;

        /// <summary>
        /// A mask that can be used in the input field. You can use it to inject additional characters to provide a better user experience and to restrict the accepted character set (illegal characters will be ignored during typing).<para />
        /// <br/>* is used for wildcards (and also chars)<para />
        /// <br/>9 is used for numbers<para />
        /// <br/>Everything outside {{ and }} is used as-is.<para />
        /// </summary>
        public string Mask { get; set; } = null;

        /// <summary>
        /// * true - The data in this field should be obfuscated as it is entered, just like a password field<para />
        /// * false - The data in this field does not need to be obfuscated<para />
        /// </summary>
        public bool? Obfuscate { get; set; } = null;

        /// <summary>
        /// A placeholder value for the form element<para />
        /// </summary>
        public string PlaceholderLabel { get; set; } = null;

        /// <summary>
        /// The type of keyboard that can best be used to fill out the value of this field. Possible values are:<para />
        /// * PhoneNumberKeyboard - Keyboard that is normally used to enter phone numbers<para />
        /// * StringKeyboard - Keyboard that is used to enter strings<para />
        /// * IntegerKeyboard - Keyboard that is used to enter only numerical values<para />
        /// * EmailAddressKeyboard - Keyboard that allows easier entry of email addresses<para />
        /// </summary>
        public string PreferredInputType { get; set; } = null;

        /// <summary>
        /// Object that contains an optional tooltip to assist the customer<para />
        /// </summary>
        public PaymentProductFieldTooltip Tooltip { get; set; } = null;
    }
}

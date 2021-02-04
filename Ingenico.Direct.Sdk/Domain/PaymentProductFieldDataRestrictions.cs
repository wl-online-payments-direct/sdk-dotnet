/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class PaymentProductFieldDataRestrictions
    {
        /// <summary>
        /// * true - Indicates that this field is required<para />
        /// * false - Indicates that this field is optional<para />
        /// </summary>
        public bool? IsRequired { get; set; } = null;

        /// <summary>
        /// Object containing the details of the validations on the field<para />
        /// </summary>
        public PaymentProductFieldValidators Validators { get; set; } = null;
    }
}

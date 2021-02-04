/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class PersonalInformation
    {
        /// <summary>
        /// The date of birth of the customer of the recipient of the loan.<para />
        /// Format YYYYMMDD<para />
        /// </summary>
        public string DateOfBirth { get; set; } = null;

        /// <summary>
        /// The gender of the customer, possible values are:<para />
        ///  * male<para />
        ///  * female<para />
        ///  * unknown or empty<para />
        /// </summary>
        public string Gender { get; set; } = null;

        /// <summary>
        /// Object containing the name details of the customer<para />
        /// </summary>
        public PersonalName Name { get; set; } = null;
    }
}

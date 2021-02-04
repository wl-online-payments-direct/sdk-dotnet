/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CustomerToken
    {
        /// <summary>
        /// Object containing billing address details<para />
        /// </summary>
        public Address BillingAddress { get; set; } = null;

        /// <summary>
        /// Object containing company information<para />
        /// </summary>
        public CompanyInformation CompanyInformation { get; set; } = null;

        public PersonalInformationToken PersonalInformation { get; set; } = null;
    }
}

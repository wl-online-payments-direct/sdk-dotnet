/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerToken
    {
        /// <summary>
        /// Object containing billing address details.
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Object containing company information
        /// </summary>
        public CompanyInformation CompanyInformation { get; set; }

        public PersonalInformationToken PersonalInformation { get; set; }
    }
}

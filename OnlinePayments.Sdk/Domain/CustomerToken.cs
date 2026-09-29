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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CustomerToken WithBillingAddress(Address value)
        {
            BillingAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CustomerToken WithCompanyInformation(CompanyInformation value)
        {
            CompanyInformation = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CustomerToken WithPersonalInformation(PersonalInformationToken value)
        {
            PersonalInformation = value;
            return this;
        }
    }
}

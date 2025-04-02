/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateCustomerResponse
    {
        /// <summary>
        /// Object containing IBAN information
        /// </summary>
        public BankAccountIban BankAccountIban { get; set; }

        /// <summary>
        /// Name of company, as a customer
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Object containing email address
        /// </summary>
        public MandateContactDetails ContactDetails { get; set; }

        /// <summary>
        /// Object containing consumer address details
        /// </summary>
        public MandateAddressResponse MandateAddress { get; set; }

        /// <summary>
        /// Object containing personal information of the customer
        /// </summary>
        public MandatePersonalInformationResponse PersonalInformation { get; set; }
    }
}

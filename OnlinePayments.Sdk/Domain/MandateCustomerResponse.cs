/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateCustomerResponse
    {
        /// <summary>
        /// Object containing IBAN information<para />
        /// </summary>
        public BankAccountIban BankAccountIban { get; set; } = null;

        /// <summary>
        /// Name of company, as a customer<para />
        /// </summary>
        public string CompanyName { get; set; } = null;

        /// <summary>
        /// Object containing email address<para />
        /// </summary>
        public MandateContactDetails ContactDetails { get; set; } = null;

        /// <summary>
        /// Object containing consumer address details<para />
        /// </summary>
        public MandateAddressResponse MandateAddress { get; set; } = null;

        /// <summary>
        /// Object containing personal information of the customer<para />
        /// </summary>
        public MandatePersonalInformationResponse PersonalInformation { get; set; } = null;
    }
}

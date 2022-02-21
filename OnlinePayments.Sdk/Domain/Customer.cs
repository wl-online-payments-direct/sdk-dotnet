/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Customer
    {
        /// <summary>
        /// Object containing data related to the account the customer has with you<para />
        /// </summary>
        public CustomerAccount Account { get; set; } = null;

        /// <summary>
        /// Type of the customer account that is used to place this order. Can have one of the following values:<para />
        ///  * none - The account that was used to place the order with is a guest account or no account was used at all<para />
        ///  * created - The customer account was created during this transaction<para />
        ///  * existing - The customer account was an already existing account prior to this transaction<para />
        /// </summary>
        public string AccountType { get; set; } = null;

        /// <summary>
        /// Object containing billing address details<para />
        /// </summary>
        public Address BillingAddress { get; set; } = null;

        /// <summary>
        /// Object containing company information<para />
        /// </summary>
        public CompanyInformation CompanyInformation { get; set; } = null;

        /// <summary>
        /// Object containing contact details like email address and phone number<para />
        /// </summary>
        public ContactDetails ContactDetails { get; set; } = null;

        /// <summary>
        /// Object containing information on the device and browser of the customer<para />
        /// </summary>
        public CustomerDevice Device { get; set; } = null;

        /// <summary>
        /// Fiscal registration number of the customer or the tax registration number of the company for a business customer. Please find below specifics per country:<para />
        ///  * Brazil - Consumer (CPF) with a length of 11 digits<para />
        ///  * Brazil - Company (CNPJ) with a length of 14 digits<para />
        ///  * Denmark - Consumer (CPR-nummer or personnummer) with a length of 10 digits<para />
        ///  * Finland - Consumer (Finnish: henkilötunnus (abbreviated as HETU), Swedish: personbeteckning) with a length of 11 characters<para />
        ///  * Norway - Consumer (fødselsnummer) with a length of 11 digits<para />
        ///  * Sweden - Consumer (personnummer) with a length of 10 or 12 digits<para />
        /// </summary>
        public string FiscalNumber { get; set; } = null;

        /// <summary>
        /// The locale that the customer should be addressed in (for 3rd parties). Note that some 3rd party providers only support the languageCode part of the locale, in those cases we will only use part of the locale provided.<para />
        /// </summary>
        public string Locale { get; set; } = null;

        /// <summary>
        /// Your identifier for the customer. It is used in the fraud-screening process for payments on the payment platform.<para />
        /// </summary>
        public string MerchantCustomerId { get; set; } = null;

        /// <summary>
        /// Object containing personal information like name, date of birth and gender.<para />
        /// </summary>
        public PersonalInformation PersonalInformation { get; set; } = null;
    }
}

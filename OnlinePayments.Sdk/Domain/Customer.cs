/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Customer
    {
        /// <summary>
        /// Object containing data related to the account the customer has with you
        /// </summary>
        public CustomerAccount Account { get; set; }

        /// <summary>
        /// Type of the customer account that is used to place this order. Can have one of the following values:
        /// <list type="bullet">
        ///   <item><description>none - The account that was used to place the order with is a guest account or no account was used at all</description></item>
        ///   <item><description>created - The customer account was created during this transaction</description></item>
        ///   <item><description>existing - The customer account was an already existing account prior to this transaction</description></item>
        /// </list>
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// Object containing billing address details.
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Object containing company information
        /// </summary>
        public CompanyInformation CompanyInformation { get; set; }

        /// <summary>
        /// Object containing contact details like email address and phone number
        /// </summary>
        public ContactDetails ContactDetails { get; set; }

        /// <summary>
        /// Object containing information on the device and browser of the customer
        /// </summary>
        public CustomerDevice Device { get; set; }

        /// <summary>
        /// Fiscal registration number of the customer or the tax registration number of the company for a business customer. Please find below specifics per country:
        /// <list type="bullet">
        ///   <item><description>Brazil - Consumer (CPF) with a length of 11 digits</description></item>
        ///   <item><description>Brazil - Company (CNPJ) with a length of 14 digits</description></item>
        ///   <item><description>Denmark - Consumer (CPR-nummer or personnummer) with a length of 10 digits</description></item>
        ///   <item><description>Finland - Consumer (Finnish: henkilÃ¶tunnus (abbreviated as HETU), Swedish: personbeteckning) with a length of 11 characters</description></item>
        ///   <item><description>Norway - Consumer (fÃ¸dselsnummer) with a length of 11 digits</description></item>
        ///   <item><description>Sweden - Consumer (personnummer) with a length of 10 or 12 digits</description></item>
        /// </list>
        /// </summary>
        public string FiscalNumber { get; set; }

        /// <summary>
        /// The locale that the customer should be addressed in (for 3rd parties). Note that some 3rd party providers only support the languageCode part of the locale, in those cases we will only use part of the locale provided.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Your identifier for the customer. It is used in the fraud-screening process for payments on the payment platform.
        /// </summary>
        public string MerchantCustomerId { get; set; }

        /// <summary>
        /// Object containing personal information like name, date of birth and gender.
        /// </summary>
        public PersonalInformation PersonalInformation { get; set; }
    }
}

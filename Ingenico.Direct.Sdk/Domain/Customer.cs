/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class Customer
    {
        public CustomerAccount Account { get; set; } = null;

        public string AccountType { get; set; } = null;

        public Address BillingAddress { get; set; } = null;

        public CompanyInformation CompanyInformation { get; set; } = null;

        public ContactDetails ContactDetails { get; set; } = null;

        public CustomerDevice Device { get; set; } = null;

        public string FiscalNumber { get; set; } = null;

        public string Locale { get; set; } = null;

        public string MerchantCustomerId { get; set; } = null;

        public PersonalInformation PersonalInformation { get; set; } = null;
    }
}

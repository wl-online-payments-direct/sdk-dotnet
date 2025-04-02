/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateCustomer
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
        /// Object containing consumer address details.
        /// Required for Create mandate and Create payment calls.
        /// Required for Create hostedCheckout calls where the IBAN is also provided.
        /// </summary>
        public MandateAddress MandateAddress { get; set; }

        /// <summary>
        /// Object containing personal information of the customer.
        /// Required for Create mandate and Create payment calls.
        /// </summary>
        public MandatePersonalInformation PersonalInformation { get; set; }
    }
}

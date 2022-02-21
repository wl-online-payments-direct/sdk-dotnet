/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateCustomer
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
        /// Object containing contact details like email address and phone number<para />
        /// </summary>
        public MandateContactDetails ContactDetails { get; set; } = null;

        /// <summary>
        /// Object containing billing address details.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// Required for Create hostedCheckout calls where the IBAN is also provided.<para />
        /// </summary>
        public MandateAddress MandateAddress { get; set; } = null;

        /// <summary>
        /// Object containing personal information of the customer.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// </summary>
        public MandatePersonalInformation PersonalInformation { get; set; } = null;
    }
}

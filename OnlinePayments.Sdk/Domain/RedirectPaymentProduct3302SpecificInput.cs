/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct3302SpecificInput
    {
        /// <summary>
        /// This parameter defines the legal form of a business  and is mandatory in B2B transactions,  Accurate classification ensures compliance and optimized payment handling.
        /// </summary>
        public string OrganizationEntityType { get; set; }

        /// <summary>
        /// Unique identifier given by relevant authority verifying a business's legal registration. Mandatory in B2B transactions
        /// </summary>
        public string OrganizationRegistrationId { get; set; }

        /// <summary>
        /// Tax identification number used to validate a business's VAT compliance. Mandatory in B2B transactions
        /// </summary>
        public string VatId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct3302SpecificInput WithOrganizationEntityType(string value)
        {
            OrganizationEntityType = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct3302SpecificInput WithOrganizationRegistrationId(string value)
        {
            OrganizationRegistrationId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct3302SpecificInput WithVatId(string value)
        {
            VatId = value;
            return this;
        }
    }
}

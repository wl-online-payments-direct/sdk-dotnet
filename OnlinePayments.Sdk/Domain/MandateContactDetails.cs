/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandateContactDetails
    {
        /// <summary>
        /// Email address of the customer
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// International version of the phone number of the customer including the leading + (i.e. +4917612345678)
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateContactDetails WithEmailAddress(string value)
        {
            EmailAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandateContactDetails WithPhoneNumber(string value)
        {
            PhoneNumber = value;
            return this;
        }
    }
}

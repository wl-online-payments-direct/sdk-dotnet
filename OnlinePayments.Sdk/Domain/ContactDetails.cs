/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ContactDetails
    {
        /// <summary>
        /// Email address of the customer
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// International version of the fax number of the customer including the leading + (i.e. +16127779311)
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// International version of the mobile phone number of the customer including the leading + (i.e. +16127779311)
        /// </summary>
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// International version of the phone number of the customer including the leading + (i.e. +16127779311)
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// International version of the work phone number of the customer including the leading + (i.e. +31235671500)
        /// </summary>
        public string WorkPhoneNumber { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ContactDetails WithEmailAddress(string value)
        {
            EmailAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ContactDetails WithFaxNumber(string value)
        {
            FaxNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ContactDetails WithMobilePhoneNumber(string value)
        {
            MobilePhoneNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ContactDetails WithPhoneNumber(string value)
        {
            PhoneNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ContactDetails WithWorkPhoneNumber(string value)
        {
            WorkPhoneNumber = value;
            return this;
        }
    }
}

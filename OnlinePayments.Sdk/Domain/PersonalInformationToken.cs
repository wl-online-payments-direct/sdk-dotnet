/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PersonalInformationToken
    {
        public PersonalNameToken Name { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PersonalInformationToken WithName(PersonalNameToken value)
        {
            Name = value;
            return this;
        }
    }
}

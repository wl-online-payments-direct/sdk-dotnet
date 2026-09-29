/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PersonalNameToken
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PersonalNameToken WithFirstName(string value)
        {
            FirstName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PersonalNameToken WithSurname(string value)
        {
            Surname = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandatePersonalNameResponse
    {
        /// <summary>
        /// Given name(s) or first name(s) of the customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname(s) or last name(s) of the customer.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandatePersonalNameResponse WithFirstName(string value)
        {
            FirstName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandatePersonalNameResponse WithSurname(string value)
        {
            Surname = value;
            return this;
        }
    }
}

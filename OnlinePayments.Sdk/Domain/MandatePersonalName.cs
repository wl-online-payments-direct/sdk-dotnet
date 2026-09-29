/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandatePersonalName
    {
        /// <summary>
        /// Given name(s) or first name(s) of the customer.
        /// Required for Create mandate and Create payment calls.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname(s) or last name(s) of the customer.
        /// Required for Create mandate and Create payment calls.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandatePersonalName WithFirstName(string value)
        {
            FirstName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandatePersonalName WithSurname(string value)
        {
            Surname = value;
            return this;
        }
    }
}

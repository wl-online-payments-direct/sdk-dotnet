/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandatePersonalInformationResponse
    {
        /// <summary>
        /// Object containing the name details of the customer.
        /// </summary>
        public MandatePersonalNameResponse Name { get; set; }

        /// <summary>
        /// Object containing the title of the customer (Mr, Miss or Mrs)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandatePersonalInformationResponse WithName(MandatePersonalNameResponse value)
        {
            Name = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandatePersonalInformationResponse WithTitle(string value)
        {
            Title = value;
            return this;
        }
    }
}

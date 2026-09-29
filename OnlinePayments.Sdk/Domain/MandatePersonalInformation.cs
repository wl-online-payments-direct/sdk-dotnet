/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandatePersonalInformation
    {
        /// <summary>
        /// Object containing the name details of the customer.
        /// Required for Create mandate and Create payment calls.
        /// </summary>
        public MandatePersonalName Name { get; set; }

        /// <summary>
        /// Object containing the title of the customer (Mr, Miss or Mrs)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandatePersonalInformation WithName(MandatePersonalName value)
        {
            Name = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public MandatePersonalInformation WithTitle(string value)
        {
            Title = value;
            return this;
        }
    }
}

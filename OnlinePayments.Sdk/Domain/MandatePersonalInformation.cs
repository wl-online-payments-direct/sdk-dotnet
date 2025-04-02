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
    }
}

/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class MandatePersonalName
    {
        /// <summary>
        /// Given name(s) or first name(s) of the customer.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// </summary>
        public string FirstName { get; set; } = null;

        /// <summary>
        /// Surname(s) or last name(s) of the customer.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// </summary>
        public string Surname { get; set; } = null;
    }
}

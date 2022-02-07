/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class MandatePersonalInformation
    {
        /// <summary>
        /// Object containing the name details of the customer.<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// </summary>
        public MandatePersonalName Name { get; set; } = null;

        /// <summary>
        /// Object containing the title of the customer (Mr, Miss or Mrs).<para />
        /// Required for Create mandate and Create payment calls.<para />
        /// </summary>
        public string Title { get; set; } = null;
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ValidateCredentialsRequest
    {
        /// <summary>
        /// The webhook key and without any change applied to it.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Send here the hashed webhooks key secret in the same way as the check is done in your system. The only difference is instead of providing the current body of the message, use an empty string as body while hashing it.
        /// </summary>
        public string Secret { get; set; }
    }
}

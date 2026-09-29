/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ValidateCredentialsResponse
    {
        /// <summary>
        /// The webhooks validation was OK (Valid) or not OK (Invalid).
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ValidateCredentialsResponse WithResult(string value)
        {
            Result = value;
            return this;
        }
    }
}

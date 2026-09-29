/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetMandateResponse
    {
        /// <summary>
        /// Object containing the created mandate.
        /// </summary>
        public MandateResponse Mandate { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetMandateResponse WithMandate(MandateResponse value)
        {
            Mandate = value;
            return this;
        }
    }
}

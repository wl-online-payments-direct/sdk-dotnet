/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AutoCapture
    {
        /// <summary>
        /// Delay in minutes between authorization and automatic capture for this request. Minimum value is 0 minutes, maximum value is 43200 minutes (30 days).
        /// </summary>
        public int? DelayInMinutes { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AutoCapture WithDelayInMinutes(int? value)
        {
            DelayInMinutes = value;
            return this;
        }
    }
}

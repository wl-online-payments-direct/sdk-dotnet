/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CaptureResponse
    {
        /// <summary>
        /// Object containing capture details<para />
        /// </summary>
        public CaptureOutput CaptureOutput { get; set; } = null;

        /// <summary>
        /// Our unique payment transaction identifier<para />
        /// </summary>
        public string Id { get; set; } = null;

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.<para />
        /// </summary>
        public string Status { get; set; } = null;

        /// <summary>
        /// This object has the numeric representation of the current capture status, timestamp of last status change and performable action on the current payment resource. In case of failed payments and negative scenarios, detailed error information is listed.<para />
        /// </summary>
        public CaptureStatusOutput StatusOutput { get; set; } = null;
    }
}

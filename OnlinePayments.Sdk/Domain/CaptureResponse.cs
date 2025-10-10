/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CaptureResponse
    {
        /// <summary>
        /// Object containing capture details
        /// </summary>
        public CaptureOutput CaptureOutput { get; set; }

        /// <summary>
        /// This is our unique payment transaction identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Current high-level status of the payment in a human-readable form.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// This object has the numeric representation of the current capture status, timestamp of last status change and performable action on the current payment resource. In case of failed payments and negative scenarios, detailed error information is listed.
        /// </summary>
        public CaptureStatusOutput StatusOutput { get; set; }
    }
}

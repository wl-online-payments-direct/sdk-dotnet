/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class LodgingData
    {
        /// <summary>
        /// The date the guest checks into (or plans to check in to) the facility.
        /// Format YYYYMMDD
        /// </summary>
        public string CheckInDate { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public LodgingData WithCheckInDate(string value)
        {
            CheckInDate = value;
            return this;
        }
    }
}

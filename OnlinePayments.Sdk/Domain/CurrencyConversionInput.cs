/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversionInput
    {
        /// <summary>
        /// Dynamic Currency Conversion(DCC) Proposal accepted by user<para />
        /// </summary>
        public bool? AcceptedByUser { get; set; } = null;

        /// <summary>
        /// Dynamic Currency Conversion(DCC) Session Id that was previously returned by rate enquiry (/dccrate).<para />
        /// </summary>
        public string DccSessionId { get; set; } = null;
    }
}

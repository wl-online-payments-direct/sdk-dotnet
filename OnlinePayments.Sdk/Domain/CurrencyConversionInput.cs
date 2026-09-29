/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CurrencyConversionInput
    {
        /// <summary>
        /// Dynamic Currency Conversion(DCC) Proposal accepted by user
        /// </summary>
        public bool? AcceptedByUser { get; set; }

        /// <summary>
        /// Dynamic Currency Conversion(DCC) Session Id that was previously returned by rate enquiry (/dccrate).
        /// </summary>
        public string DccSessionId { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CurrencyConversionInput WithAcceptedByUser(bool? value)
        {
            AcceptedByUser = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CurrencyConversionInput WithDccSessionId(string value)
        {
            DccSessionId = value;
            return this;
        }
    }
}

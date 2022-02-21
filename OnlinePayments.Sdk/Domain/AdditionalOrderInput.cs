/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AdditionalOrderInput
    {
        /// <summary>
        /// Object that holds airline specific data<para />
        /// </summary>
        public AirlineData AirlineData { get; set; } = null;

        /// <summary>
        /// Object containing specific data regarding the recipient of a loan in the UK<para />
        /// </summary>
        public LoanRecipient LoanRecipient { get; set; } = null;

        /// <summary>
        /// Object that holds lodging specific data<para />
        /// </summary>
        public LodgingData LodgingData { get; set; } = null;

        /// <summary>
        /// Object that holds the purchase and usage type indicators<para />
        /// </summary>
        public OrderTypeInformation TypeInformation { get; set; } = null;
    }
}

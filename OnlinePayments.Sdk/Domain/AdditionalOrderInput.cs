/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AdditionalOrderInput
    {
        /// <summary>
        /// Object that holds airline specific data
        /// </summary>
        public AirlineData AirlineData { get; set; }

        /// <summary>
        /// Object containing specific data regarding the recipient of a loan in the UK
        /// </summary>
        public LoanRecipient LoanRecipient { get; set; }

        /// <summary>
        /// Object that holds lodging specific data
        /// </summary>
        public LodgingData LodgingData { get; set; }

        /// <summary>
        /// Object that holds the purchase and usage type indicators
        /// </summary>
        public OrderTypeInformation TypeInformation { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AdditionalOrderInput WithAirlineData(AirlineData value)
        {
            AirlineData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AdditionalOrderInput WithLoanRecipient(LoanRecipient value)
        {
            LoanRecipient = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AdditionalOrderInput WithLodgingData(LodgingData value)
        {
            LodgingData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AdditionalOrderInput WithTypeInformation(OrderTypeInformation value)
        {
            TypeInformation = value;
            return this;
        }
    }
}

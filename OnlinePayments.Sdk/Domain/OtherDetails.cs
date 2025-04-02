/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OtherDetails
    {
        /// <summary>
        /// Information used by the following PaymentProducts [5300] to provide details on the item such as the color, size, etc. The field is in JSON format, with keys and values expected by the payment method at transaction creation. Please refer to the payment mean documentation.
        /// </summary>
        public string MetaData { get; set; }

        /// <summary>
        /// Information used by the following PaymentProducts [5110,5111,5112,5125,3104,3107,3108,3109].
        /// </summary>
        public string TravelData { get; set; }
    }
}

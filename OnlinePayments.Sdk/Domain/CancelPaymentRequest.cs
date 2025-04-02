/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CancelPaymentRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// This property indicates whether this will be the final operation. The default value for this property is false.
        /// </summary>
        public bool? IsFinal { get; set; }
    }
}

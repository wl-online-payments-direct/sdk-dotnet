/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CancelPaymentRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// This property indicates whether this will be the final operation. The default value for this property is false.<para />
        /// </summary>
        public bool? IsFinal { get; set; } = null;
    }
}

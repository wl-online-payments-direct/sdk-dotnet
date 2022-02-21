/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CapturePaymentRequest
    {
        /// <summary>
        /// Here you can specify the amount that you want to capture (specified in cents, where single digit currencies are presumed to have 2 digits). The amount can be lower than the amount that was authorized, but not higher. <para />
        ///  If left empty, the full amount will be captured and the request will be final. <para />
        ///  If the full amount is captured, the request will also be final.<para />
        /// </summary>
        public long? Amount { get; set; } = null;

        /// <summary>
        /// This property indicates whether this will be the final capture of this transaction. The default value for this property is false.<para />
        /// </summary>
        public bool? IsFinal { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// </summary>
        public PaymentReferences References { get; set; } = null;
    }
}

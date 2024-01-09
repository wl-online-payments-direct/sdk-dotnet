/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreatePaymentLinkRequest
    {
        /// <summary>
        /// A note related to the created payment link.<para />
        /// </summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// The date after which the payment link will not be usable to complete the payment. The date sent cannot be more than 30 days in the future or a past date. It must also contain the UTC offset.<para />
        /// </summary>
        public string ExpirationDate { get; set; } = null;

        /// <summary>
        /// An object containing the details of the related payment input.<para />
        /// </summary>
        public PaymentLinkOrderInput PaymentLinkOrder { get; set; } = null;

        /// <summary>
        /// The payment link recipient name.<para />
        /// </summary>
        public string RecipientName { get; set; } = null;
    }
}

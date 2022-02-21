/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetIINDetailsRequest
    {
        /// <summary>
        /// The first digits of the credit card number from left to right with a minimum of 6 digits. Providing additional digits can result in more co-brands being returned.<para />
        /// </summary>
        public string Bin { get; set; } = null;

        public PaymentContext PaymentContext { get; set; } = null;
    }
}

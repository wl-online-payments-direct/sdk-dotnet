/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GetIINDetailsRequest
    {
        /// <summary>
        /// The first digits of the credit card number from left to right with a minimum of 6 digits. Providing additional digits (up to 19) can result in more co-brands being returned.
        /// </summary>
        public string Bin { get; set; }

        public PaymentContext PaymentContext { get; set; }
    }
}

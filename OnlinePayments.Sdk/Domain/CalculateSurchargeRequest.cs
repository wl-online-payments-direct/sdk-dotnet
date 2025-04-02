/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CalculateSurchargeRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Contains elements from which card number can be obtained.
        /// </summary>
        public CardSource CardSource { get; set; }
    }
}

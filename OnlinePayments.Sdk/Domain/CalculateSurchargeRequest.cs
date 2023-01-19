/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CalculateSurchargeRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Contains elements from which card number can be obtained.<para />
        /// </summary>
        public CardSource CardSource { get; set; } = null;
    }
}

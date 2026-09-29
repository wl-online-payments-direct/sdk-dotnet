/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Transaction
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney Amount { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Transaction WithAmount(AmountOfMoney value)
        {
            Amount = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class IncrementAuthorizationRequest
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public IncrementAuthorizationRequest WithAmountOfMoney(AmountOfMoney value)
        {
            AmountOfMoney = value;
            return this;
        }
    }
}

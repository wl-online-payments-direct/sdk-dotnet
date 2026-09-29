/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class GiftCardPurchase
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Number of gift cards that are purchased through this transaction
        /// </summary>
        public int? NumberOfGiftCards { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GiftCardPurchase WithAmountOfMoney(AmountOfMoney value)
        {
            AmountOfMoney = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GiftCardPurchase WithNumberOfGiftCards(int? value)
        {
            NumberOfGiftCards = value;
            return this;
        }
    }
}

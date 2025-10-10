/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Order
    {
        /// <summary>
        /// This object contains additional input on the order.
        /// </summary>
        public AdditionalOrderInput AdditionalInput { get; set; }

        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Object containing the details of the customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Object to apply a discount to the total basket by adding a discount line.
        /// </summary>
        public Discount Discount { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction
        /// </summary>
        public OrderReferences References { get; set; }

        /// <summary>
        /// Object containing information regarding shipping / delivery
        /// </summary>
        public Shipping Shipping { get; set; }

        /// <summary>
        /// Shopping cart data, including items and specific amounts.
        /// </summary>
        public ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Object containing specific input required to apply surcharging to an order.
        /// </summary>
        public SurchargeSpecificInput SurchargeSpecificInput { get; set; }

        /// <summary>
        /// tax amount, in minor currency units of the order. Omit if not applicable or not known. This amount is assumed to be included in the order.AmountOfMoney for the payment. There is no validation on this field, outside the fact the amount should be lower than the total payment amount.
        /// </summary>
        public long? TotalTaxAmount { get; set; }
    }
}

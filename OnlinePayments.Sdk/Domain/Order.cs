/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Order
    {
        /// <summary>
        /// Object containing additional input on the order
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
    }
}

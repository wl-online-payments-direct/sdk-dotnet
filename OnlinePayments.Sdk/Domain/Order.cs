/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Order
    {
        /// <summary>
        /// Object containing additional input on the order<para />
        /// </summary>
        public AdditionalOrderInput AdditionalInput { get; set; } = null;

        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Object containing the details of the customer<para />
        /// </summary>
        public Customer Customer { get; set; } = null;

        /// <summary>
        /// Object to apply a discount to the total basket by adding a discount line.<para />
        /// </summary>
        public Discount Discount { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// </summary>
        public OrderReferences References { get; set; } = null;

        /// <summary>
        /// Object containing information regarding shipping / delivery<para />
        /// </summary>
        public Shipping Shipping { get; set; } = null;

        /// <summary>
        /// Shopping cart data, including items and specific amounts.<para />
        /// </summary>
        public ShoppingCart ShoppingCart { get; set; } = null;

        /// <summary>
        /// Object containing specific input required to apply surcharging to an order.<para />
        /// </summary>
        public SurchargeSpecificInput SurchargeSpecificInput { get; set; } = null;
    }
}

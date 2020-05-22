/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class Order
    {
        public AdditionalOrderInput AdditionalInput { get; set; } = null;

        public AmountOfMoney AmountOfMoney { get; set; } = null;

        public Customer Customer { get; set; } = null;

        public OrderReferences References { get; set; } = null;

        public Shipping Shipping { get; set; } = null;

        public ShoppingCart ShoppingCart { get; set; } = null;
    }
}

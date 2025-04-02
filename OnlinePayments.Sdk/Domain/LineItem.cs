/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class LineItem
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Object containing the line items of the invoice or shopping cart
        /// </summary>
        public LineItemInvoiceData InvoiceData { get; set; }

        /// <summary>
        /// Object containing additional information that when supplied can have a beneficial effect on the discountrates
        /// </summary>
        public OrderLineDetails OrderLineDetails { get; set; }

        /// <summary>
        /// Other information for specific payment methods.
        /// </summary>
        public OtherDetails OtherDetails { get; set; }
    }
}

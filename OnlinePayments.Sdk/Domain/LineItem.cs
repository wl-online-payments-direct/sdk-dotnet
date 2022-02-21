/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class LineItem
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Object containing the line items of the invoice or shopping cart<para />
        /// </summary>
        public LineItemInvoiceData InvoiceData { get; set; } = null;

        /// <summary>
        /// Object containing additional information that when supplied can have a beneficial effect on the discountrates<para />
        /// </summary>
        public OrderLineDetails OrderLineDetails { get; set; } = null;
    }
}

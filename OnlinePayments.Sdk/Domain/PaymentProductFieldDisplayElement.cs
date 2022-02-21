/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFieldDisplayElement
    {
        /// <summary>
        /// The ID of the display element.<para />
        /// </summary>
        public string Id { get; set; } = null;

        /// <summary>
        /// The label of the display element.<para />
        /// </summary>
        public string Label { get; set; } = null;

        /// <summary>
        /// The type of the display element. Indicates how the value should be presented. Possible values are:<para />
        /// * STRING - as plain text<para />
        /// * CURRENCY - as an amount in cents displayed with a decimal separator and the currency of the payment<para />
        /// * PERCENTAGE - as a number with a percentage sign<para />
        /// * INTEGER - as an integer<para />
        /// * URI - as a link<para />
        /// </summary>
        public string Type { get; set; } = null;

        /// <summary>
        /// the value of the display element.<para />
        /// </summary>
        public string Value { get; set; } = null;
    }
}

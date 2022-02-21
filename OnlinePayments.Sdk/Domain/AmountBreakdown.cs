/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AmountBreakdown
    {
        /// <summary>
        /// Amount in cents and always having 2 decimals<para />
        /// </summary>
        public long? Amount { get; set; } = null;

        /// <summary>
        /// Type of the amount. Each type is only allowed to be provided once. Allowed values:<para />
        ///  * AIRPORT_TAX - The amount of tax paid for the airport, with the last 2 digits implied as decimal places.<para />
        ///  * CONSUMPTION_TAX - The amount of consumption tax paid by the customer, with the last 2 digits implied as decimal places.<para />
        ///  * DISCOUNT - Discount on the entire transaction, with the last 2 digits implied as decimal places.<para />
        ///  * DUTY - Duty on the entire transaction, with the last 2 digits implied as decimal places.<para />
        ///  * SHIPPING - Shipping cost on the entire transaction, with the last 2 digits implied as decimal places.<para />
        ///  * VAT - Total amount of VAT paid on the transaction, with the last 2 digits implied as decimal places.<para />
        ///  * BASE_AMOUNT - Order amount excluding all taxes, discount & shipping costs, with the last 2 digits implied as decimal places. Note: BASE_AMOUNT is only supported by the payment platform.<para />
        /// </summary>
        public string Type { get; set; } = null;
    }
}

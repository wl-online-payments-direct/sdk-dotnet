/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentLinkOverviewSorting
    {
        /// <summary>
        /// The direction to sort the results. Possible values are:
        /// <list type="bullet">
        ///   <item><description>ascending - Sort in ascending order.</description></item>
        ///   <item><description>descending - Sort in descending order.</description></item>
        /// </list>
        /// </summary>
        public string SortDirection { get; set; }

        /// <summary>
        /// The property to sort the results by. Possible values are:
        /// <list type="bullet">
        ///   <item><description>creationDate - Sort by the date the payment link was created.</description></item>
        ///   <item><description>expirationDate - Sort by the expiration date of the payment link.</description></item>
        ///   <item><description>merchantId - Sort by the merchant ID of the payment link.</description></item>
        ///   <item><description>status - Sort by the status of the payment link.</description></item>
        /// </list>
        /// </summary>
        public string SortProperty { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewSorting WithSortDirection(string value)
        {
            SortDirection = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentLinkOverviewSorting WithSortProperty(string value)
        {
            SortProperty = value;
            return this;
        }
    }
}

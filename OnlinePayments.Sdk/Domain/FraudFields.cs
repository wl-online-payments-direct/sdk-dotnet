/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class FraudFields
    {
        /// <summary>
        /// Additional black list input<para />
        /// </summary>
        public string BlackListData { get; set; } = null;

        /// <summary>
        /// Deprecated: Use order.customer.device.ipAddress instead.<para />
        /// <para />
        /// The IP Address of the customer that is making the payment<para />
        /// </summary>
        public string CustomerIpAddress { get; set; } = null;

        /// <summary>
        /// List of product categories that are being purchased.<para />
        /// </summary>
        public IList<string> ProductCategories { get; set; } = null;
    }
}

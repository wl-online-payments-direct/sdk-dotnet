/*
 * This file was automatically generated.
 */
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class FraudFields
    {
        /// <summary>
        /// Additional black list input
        /// </summary>
        public string BlackListData { get; set; }

        /// <summary>
        /// Deprecated: Use order.customer.device.ipAddress instead.
        /// <p />
        /// The IP Address of the customer that is making the payment
        /// </summary>
        [Obsolete("Use order.customer.device.ipAddress instead.  The IP Address of the customer that is making the payment")]
        public string CustomerIpAddress { get; set; }

        /// <summary>
        /// List of product categories that are being purchased.
        /// </summary>
        public IList<string> ProductCategories { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public FraudFields WithBlackListData(string value)
        {
            BlackListData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        [Obsolete("Use order.customer.device.ipAddress instead.  The IP Address of the customer that is making the payment")]
        public FraudFields WithCustomerIpAddress(string value)
        {
            CustomerIpAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public FraudFields WithProductCategories(IList<string> value)
        {
            ProductCategories = value;
            return this;
        }
    }
}

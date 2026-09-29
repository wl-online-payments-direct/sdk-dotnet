/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class GetPaymentProductsResponse
    {
        /// <summary>
        /// Array containing payment products and their characteristics
        /// </summary>
        public IList<PaymentProduct> PaymentProducts { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetPaymentProductsResponse WithPaymentProducts(IList<PaymentProduct> value)
        {
            PaymentProducts = value;
            return this;
        }
    }
}

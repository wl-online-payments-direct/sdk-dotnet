/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class CalculateSurchargeResponse
    {
        /// <summary>
        /// List of surcharge calculations matching the bin and paymentProductId if supplied
        /// </summary>
        public IList<Surcharge> Surcharges { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CalculateSurchargeResponse WithSurcharges(IList<Surcharge> value)
        {
            Surcharges = value;
            return this;
        }
    }
}

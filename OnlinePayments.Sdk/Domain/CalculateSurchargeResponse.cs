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
    }
}

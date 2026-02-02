/*
 * This file was automatically generated.
 */
using System;
using Newtonsoft.Json;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct11SpecificInput
    {
        /// <summary>
        /// The first installment date must be given in the YYYYMMDD format.
        /// </summary>
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime FirstInstallmentPaymentDate { get; set; }
    }
}

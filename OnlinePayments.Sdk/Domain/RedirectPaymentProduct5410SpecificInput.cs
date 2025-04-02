/*
 * This file was automatically generated.
 */
using System;
using Newtonsoft.Json;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct5410SpecificInput
    {
        /// <summary>
        /// The date of the second installment (YYYYMMDD)
        /// </summary>
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime SecondInstallmentPaymentDate { get; set; }
    }
}

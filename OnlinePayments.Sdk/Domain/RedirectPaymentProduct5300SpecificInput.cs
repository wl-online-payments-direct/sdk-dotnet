/*
 * This file was automatically generated.
 */
using System;
using Newtonsoft.Json;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct5300SpecificInput
    {
        /// <summary>
        /// The city of the address where the customer was born
        /// </summary>
        public string BirthCity { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code of the address where the customer was born
        /// </summary>
        public string BirthCountry { get; set; }

        /// <summary>
        /// The zip code of the address where the customer was born
        /// </summary>
        public string BirthZipCode { get; set; }

        /// <summary>
        /// The channel used by the customer
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// The number of customer's loyalty card or program
        /// </summary>
        public string LoyaltyCardNumber { get; set; }

        /// <summary>
        /// The date of the second installment (YYYYMMDD)
        /// </summary>
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime SecondInstallmentPaymentDate { get; set; }

        /// <summary>
        /// The duration of the session in seconds
        /// </summary>
        public int? SessionDuration { get; set; }
    }
}

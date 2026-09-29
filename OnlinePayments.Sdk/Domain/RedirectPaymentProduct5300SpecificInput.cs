/*
 * This file was automatically generated.
 */
using System;

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
        public string SecondInstallmentPaymentDate { get; set; }

        /// <summary>
        /// The duration of the session in seconds
        /// </summary>
        public int? SessionDuration { get; set; }

        /// <summary>
        /// Descriptive text that is used towards the customer, either during an online checkout at a third party or on the customer's statement.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The date and time after which the transaction will expire in UTC (format YYYY-MM-DDTHH:mm:ssZ)
        /// </summary>
        public DateTimeOffset? TransactionExpirationDateTime { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithBirthCity(string value)
        {
            BirthCity = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithBirthCountry(string value)
        {
            BirthCountry = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithBirthZipCode(string value)
        {
            BirthZipCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithChannel(string value)
        {
            Channel = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithLoyaltyCardNumber(string value)
        {
            LoyaltyCardNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithSecondInstallmentPaymentDate(string value)
        {
            SecondInstallmentPaymentDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithSessionDuration(int? value)
        {
            SessionDuration = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithTitle(string value)
        {
            Title = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RedirectPaymentProduct5300SpecificInput WithTransactionExpirationDateTime(DateTimeOffset? value)
        {
            TransactionExpirationDateTime = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
using System;
using Newtonsoft.Json;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class CardEssentials
    {
        /// <summary>
        /// The first digits of the credit card number from left to right with a minimum of 6 digits.
        /// </summary>
        public string Bin { get; set; }

        /// <summary>
        /// Indicates whether the card is an Enterprise / Commercial card or not
        /// </summary>
        public bool? CardCorporateIndicator { get; set; }

        /// <summary>
        /// The card effective date (YYYY-MM-DD)
        /// </summary>
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime CardEffectiveDate { get; set; }

        /// <summary>
        /// Indicator of existence of a card effective date
        /// </summary>
        public bool? CardEffectiveDateIndicator { get; set; }

        /// <summary>
        /// The masked credit/debit card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// PAN type sent
        /// <list type="bullet">
        ///   <item><description><c>dpan</c> Digital PAN</description></item>
        ///   <item><description><c>pan</c> Real PAN</description></item>
        /// </list>
        /// </summary>
        public string CardPanType { get; set; }

        /// <summary>
        /// Product code of the card
        /// </summary>
        public string CardProductCode { get; set; }

        /// <summary>
        /// Profile name of the card which is displayed on payment electronic ticket in accordance with MPADS requirements
        /// <list type="bullet">
        ///   <item><description><c>commercial</c> Business card</description></item>
        ///   <item><description><c>credit</c> Credit card</description></item>
        ///   <item><description><c>debit</c> Debit card</description></item>
        ///   <item><description><c>prepaid</c> Prepaid card</description></item>
        /// </list>
        /// </summary>
        public string CardProductUsageLabel { get; set; }

        /// <summary>
        /// Network name associated with the card that is informational only and not to be coded against
        /// <list type="bullet">
        ///   <item><description><c>AmericanExpress</c> American Express scheme</description></item>
        ///   <item><description><c>Bancontact</c> Bancontact scheme</description></item>
        ///   <item><description><c>Cb</c> Cartes Bancaires scheme</description></item>
        ///   <item><description><c>Cup</c> China UnionPay scheme</description></item>
        ///   <item><description><c>Dankort</c> Dankort scheme</description></item>
        ///   <item><description><c>DinersDiscover</c> Diners Discover scheme</description></item>
        ///   <item><description><c>Eftpos</c> eftpos scheme</description></item>
        ///   <item><description><c>Jcb</c> Japan Credit Bureau scheme</description></item>
        ///   <item><description><c>Mastercard</c> Mastercard scheme</description></item>
        ///   <item><description><c>Oney</c> Oney scheme</description></item>
        ///   <item><description><c>Uatp</c> Universal Air Travel Plan scheme</description></item>
        ///   <item><description><c>Visa</c> Visa scheme</description></item>
        /// </list>
        /// </summary>
        public string CardScheme { get; set; }

        /// <summary>
        /// The card's type as categorised by the payment method. Possible values are:
        /// <list type="bullet">
        ///   <item><description>Credit</description></item>
        ///   <item><description>Debit</description></item>
        ///   <item><description>Prepaid</description></item>
        /// </list>
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Expiry date of the card
        /// Format: MMYY
        /// </summary>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// Issuer code of the card
        /// </summary>
        public string IssuerCode { get; set; }

        /// <summary>
        /// Issuer name of the card
        /// </summary>
        public string IssuerName { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code in which the card has been issued
        /// </summary>
        public string IssuingCountryCode { get; set; }

        /// <summary>
        /// Maximum length of the PAN
        /// </summary>
        public int? PanLengthMax { get; set; }

        /// <summary>
        /// Minimal length of the PAN
        /// </summary>
        public int? PanLengthMin { get; set; }

        /// <summary>
        /// Indicates whether the PAN is controlled with Lühn Key algorithm
        /// </summary>
        public bool? PanLuhnCheck { get; set; }
    }
}

/*
 * This file was automatically generated.
 */
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class GetIINDetailsResponse
    {
        /// <summary>
        /// Indicates whether the card is an Enterprise / Commercial card or not
        /// </summary>
        public bool? CardCorporateIndicator { get; set; }

        /// <summary>
        /// The card effective date (YYYY-MM-DD)
        /// </summary>
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime? CardEffectiveDate { get; set; }

        /// <summary>
        /// Indicator of existence of a card effective date
        /// </summary>
        public bool? CardEffectiveDateIndicator { get; set; }

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
        /// Product name of the card
        /// </summary>
        public string CardProductName { get; set; }

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
        /// List of IIN details
        /// </summary>
        public IList<IINDetail> CoBrands { get; set; }

        /// <summary>
        /// The ISO 3166-1 alpha-2 country code of the card issuer. If we do not know the country of the card issuer, then the countryCode will return the value '99'.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Populated only if you submitted a payment context.
        /// <list type="bullet">
        ///   <item><description>true - The payment product is allowed in the submitted context.</description></item>
        ///   <item><description>false - The payment product is not allowed in the submitted context. Note that in this case, none of the brands of the card will be allowed in the submitted context.</description></item>
        /// </list>
        /// </summary>
        public bool? IsAllowedInContext { get; set; }

        /// <summary>
        /// Issuer code of the card
        /// </summary>
        public string IssuerCode { get; set; }

        /// <summary>
        /// Issuer name of the card
        /// </summary>
        public string IssuerName { get; set; }

        /// <summary>
        /// Code that identifies the principal member within an issuer group
        /// </summary>
        public string IssuerPrincipalMemberCode { get; set; }

        /// <summary>
        /// Name that identifies the principal member within an issuer group
        /// </summary>
        public string IssuerPrincipalMemberName { get; set; }

        /// <summary>
        /// Region code of the card issuer
        /// <list type="bullet">
        ///   <item><description><c>1</c> USA: California, Hawaii, Nevada</description></item>
        ///   <item><description><c>2</c> USA: West except California, Hawaii, Nevada</description></item>
        ///   <item><description><c>3</c> USA: Central North</description></item>
        ///   <item><description><c>4</c> USA: Central South</description></item>
        ///   <item><description><c>5</c> USA: Great Lakes states</description></item>
        ///   <item><description><c>6</c> USA: South East</description></item>
        ///   <item><description><c>7</c> USA: Extreme North East</description></item>
        ///   <item><description><c>8</c> USA: North East</description></item>
        ///   <item><description><c>9</c> USA: Florida and Georgia</description></item>
        ///   <item><description><c>a</c> Canada</description></item>
        ///   <item><description><c>b</c> South America</description></item>
        ///   <item><description><c>c</c> Oceania and Asia</description></item>
        ///   <item><description><c>d</c> Europe</description></item>
        ///   <item><description><c>e</c> Africa and Middle East</description></item>
        /// </list>
        /// </summary>
        public string IssuerRegionCode { get; set; }

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

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Indicates whether the card is a virtual card
        /// </summary>
        public bool? VirtualCardIndicator { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardCorporateIndicator(bool? value)
        {
            CardCorporateIndicator = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardEffectiveDate(DateTime? value)
        {
            CardEffectiveDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardEffectiveDateIndicator(bool? value)
        {
            CardEffectiveDateIndicator = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardPanType(string value)
        {
            CardPanType = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardProductCode(string value)
        {
            CardProductCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardProductName(string value)
        {
            CardProductName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardProductUsageLabel(string value)
        {
            CardProductUsageLabel = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardScheme(string value)
        {
            CardScheme = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCardType(string value)
        {
            CardType = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCoBrands(IList<IINDetail> value)
        {
            CoBrands = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithCountryCode(string value)
        {
            CountryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithIsAllowedInContext(bool? value)
        {
            IsAllowedInContext = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithIssuerCode(string value)
        {
            IssuerCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithIssuerName(string value)
        {
            IssuerName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithIssuerPrincipalMemberCode(string value)
        {
            IssuerPrincipalMemberCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithIssuerPrincipalMemberName(string value)
        {
            IssuerPrincipalMemberName = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithIssuerRegionCode(string value)
        {
            IssuerRegionCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithIssuingCountryCode(string value)
        {
            IssuingCountryCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithPanLengthMax(int? value)
        {
            PanLengthMax = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithPanLengthMin(int? value)
        {
            PanLengthMin = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithPanLuhnCheck(bool? value)
        {
            PanLuhnCheck = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public GetIINDetailsResponse WithVirtualCardIndicator(bool? value)
        {
            VirtualCardIndicator = value;
            return this;
        }
    }
}

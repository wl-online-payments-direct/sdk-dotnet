/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class AirlineData
    {
        /// <summary>
        /// Numeric code identifying the agent<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public string AgentNumericCode { get; set; } = null;

        /// <summary>
        /// Airline numeric code<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public string Code { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// Date of the Flight<para />
        /// Format: YYYYMMDD<para />
        /// </summary>
        public string FlightDate { get; set; } = null;

        /// <summary>
        /// Indicator representing the type of flight on the itinerary.<para />
        /// </summary>
        public string FlightIndicator { get; set; } = null;

        /// <summary>
        /// Object that holds the data on the individual legs of the flight ticket<para />
        /// </summary>
        public IList<AirlineFlightLeg> FlightLegs { get; set; } = null;

        /// <summary>
        /// Airline tracing number<para />
        /// This field is used by the following payment products: cards<para />
        /// </summary>
        public string InvoiceNumber { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        ///  * true = The ticket is an E-Ticket<para />
        ///  * false = the ticket is not an E-Ticket'<para />
        /// </summary>
        public bool? IsETicket { get; set; } = null;

        /// <summary>
        /// Indicates if the ticket is refundable or not.<para />
        ///  * true - Restricted, the ticket is non-refundable<para />
        ///  * false - No restrictions, the ticket is (partially) refundable<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public bool? IsRestrictedTicket { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        ///  * true - The payer is the ticket holder<para />
        ///  * false - The payer is not the ticket holder<para />
        /// </summary>
        public bool? IsThirdParty { get; set; } = null;

        /// <summary>
        /// This is the date of issue recorded in the airline system In a case of multiple issuances of the same ticket to a cardholder, you should use the last ticket date.<para />
        /// Format: YYYYMMDD<para />
        /// This field is used by the following payment products: cards, 840<para />
        /// </summary>
        public string IssueDate { get; set; } = null;

        /// <summary>
        /// Your ID of the customer in the context of the airline data<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public string MerchantCustomerId { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// Name of the airline<para />
        /// </summary>
        public string Name { get; set; } = null;

        /// <summary>
        /// Deprecated: Use passengers instead<para />
        /// Name of passenger<para />
        /// </summary>
        public string PassengerName { get; set; } = null;

        /// <summary>
        /// Object that holds the data on the individual passengers<para />
        /// This field is used by the following payment products: cards, 840<para />
        /// </summary>
        public IList<AirlinePassenger> Passengers { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// Place of issue<para />
        /// For sales in the US the last two characters (pos 14-15) must be the US state code.<para />
        /// </summary>
        public string PlaceOfIssue { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// Passenger name record<para />
        /// </summary>
        public string Pnr { get; set; } = null;

        /// <summary>
        /// IATA point of sale name<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public string PointOfSale { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// City code of the point of sale<para />
        /// </summary>
        public string PosCityCode { get; set; } = null;

        /// <summary>
        /// Three-letter ISO currency code representing the currency in which ticket purchase amount is expressed.<para />
        /// </summary>
        public string TicketCurrency { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// Delivery method of the ticket<para />
        /// </summary>
        public string TicketDeliveryMethod { get; set; } = null;

        /// <summary>
        /// The ticket or document number contains:<para />
        ///  * Airline code: 3-digit airline code number<para />
        ///  * Form code: A maximum of 3 digits indicating the type of document, the source of issue and the number of coupons it contains<para />
        ///  * Serial number: A maximum of 8 digits allocated on a sequential basis, provided that the total number of digits allocated to the form code and serial number shall not exceed ten<para />
        ///  * TICKETNUMBER can be replaced with PNR if the ticket number is unavailable<para />
        /// This field is used by the following payment products: cards, 840<para />
        /// </summary>
        public string TicketNumber { get; set; } = null;

        /// <summary>
        /// Total fare for all legs on the ticket, excluding taxes and fees. If multiple tickets are purchased, this is the total fare for all tickets<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public int? TotalFare { get; set; } = null;

        /// <summary>
        /// Total fee for all legs on the ticket. If multiple tickets are purchased, this is the total fee for all tickets<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public int? TotalFee { get; set; } = null;

        /// <summary>
        /// Total taxes for all legs on the ticket. If multiple tickets are purchased, this is the total taxes for all tickets<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public int? TotalTaxes { get; set; } = null;

        /// <summary>
        /// Name of the travel agency issuing the ticket. For direct airline integration, leave this property blank<para />
        /// This field is used by the following payment products: 840<para />
        /// </summary>
        public string TravelAgencyName { get; set; } = null;
    }
}

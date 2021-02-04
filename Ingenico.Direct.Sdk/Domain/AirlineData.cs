/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using System.Collections.Generic;

namespace Ingenico.Direct.Sdk.Domain
{
    public class AirlineData
    {
        /// <summary>
        /// Numeric code identifying the agent<para />
        /// </summary>
        public string AgentNumericCode { get; set; } = null;

        /// <summary>
        /// Airline numeric code<para />
        /// </summary>
        public string Code { get; set; } = null;

        /// <summary>
        /// Date of the Flight<para />
        /// Format: YYYYMMDD<para />
        /// </summary>
        public string FlightDate { get; set; } = null;

        /// <summary>
        /// Object that holds the data on the individual legs of the flight ticket<para />
        /// </summary>
        public IList<AirlineFlightLeg> FlightLegs { get; set; } = null;

        /// <summary>
        /// Airline tracing number<para />
        /// </summary>
        public string InvoiceNumber { get; set; } = null;

        /// <summary>
        /// * true = The ticket is an E-Ticket<para />
        /// * false = the ticket is not an E-Ticket'<para />
        /// </summary>
        public bool? IsETicket { get; set; } = null;

        /// <summary>
        /// * true - Restricted, the ticket is non-refundable<para />
        /// * false - No restrictions, the ticket is (partially) refundable<para />
        /// </summary>
        public bool? IsRestrictedTicket { get; set; } = null;

        /// <summary>
        /// * true - The payer is the ticket holder<para />
        /// * false - The payer is not the ticket holder<para />
        /// </summary>
        public bool? IsThirdParty { get; set; } = null;

        /// <summary>
        /// This is the date of issue recorded in the airline system In a case of multiple issuances of the same ticket to a cardholder, you should use the last ticket date.<para />
        /// Format: YYYYMMDD<para />
        /// </summary>
        public string IssueDate { get; set; } = null;

        /// <summary>
        /// Your ID of the customer in the context of the airline data<para />
        /// </summary>
        public string MerchantCustomerId { get; set; } = null;

        /// <summary>
        /// Name of the airline<para />
        /// </summary>
        public string Name { get; set; } = null;

        /// <summary>
        /// Name of passenger<para />
        /// </summary>
        public string PassengerName { get; set; } = null;

        /// <summary>
        /// Object that holds the data on the individual passengers (this object is used for fraud screening on the Ogone Payment Platform)<para />
        /// </summary>
        public IList<AirlinePassenger> Passengers { get; set; } = null;

        /// <summary>
        /// Place of issue<para />
        /// For sales in the US the last two characters (pos 14-15) must be the US state code.<para />
        /// </summary>
        public string PlaceOfIssue { get; set; } = null;

        /// <summary>
        /// Passenger name record<para />
        /// </summary>
        public string Pnr { get; set; } = null;

        /// <summary>
        /// IATA point of sale name<para />
        /// </summary>
        public string PointOfSale { get; set; } = null;

        /// <summary>
        /// city code of the point of sale<para />
        /// </summary>
        public string PosCityCode { get; set; } = null;

        public string TicketDeliveryMethod { get; set; } = null;

        /// <summary>
        /// The ticket or document number contains:<para />
        ///  * Airline code: 3-digit airline code number<para />
        ///  * Form code: A maximum of 3 digits indicating the type of document, the source of issue and the number of coupons it contains<para />
        ///  * Serial number: A maximum of 8 digits allocated on a sequential basis, provided that the total number of digits allocated to the form code and serial number shall not exceed ten<para />
        ///  * TICKETNUMBER can be replaced with PNR if the ticket number is unavailable<para />
        /// </summary>
        public string TicketNumber { get; set; } = null;

        /// <summary>
        /// Total fare for all legs on the ticket, excluding taxes and fees. If multiple tickets are purchased, this is the total fare for all tickets<para />
        /// </summary>
        public int? TotalFare { get; set; } = null;

        /// <summary>
        /// Total fee for all legs on the ticket. If multiple tickets are purchased, this is the total fee for all tickets<para />
        /// </summary>
        public int? TotalFee { get; set; } = null;

        /// <summary>
        /// Total taxes for all legs on the ticket. If multiple tickets are purchased, this is the total taxes for all tickets<para />
        /// </summary>
        public int? TotalTaxes { get; set; } = null;

        /// <summary>
        /// Name of the travel agency issuing the ticket. For direct airline integration, leave this property blank<para />
        /// </summary>
        public string TravelAgencyName { get; set; } = null;
    }
}

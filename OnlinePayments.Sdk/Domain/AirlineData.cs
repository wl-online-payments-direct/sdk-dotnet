/*
 * This file was automatically generated.
 */
using System;
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class AirlineData
    {
        /// <summary>
        /// Numeric code identifying the agent
        /// This field is used by the following payment products: 840
        /// </summary>
        public string AgentNumericCode { get; set; }

        /// <summary>
        /// Airline numeric code
        /// This field is used by the following payment products: 840
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// Date of the Flight
        /// Format: YYYYMMDD
        /// </summary>
        [Obsolete("This field is not used by any payment product Date of the Flight Format: YYYYMMDD")]
        public string FlightDate { get; set; }

        /// <summary>
        /// Indicator representing the type of flight on the itinerary.
        /// </summary>
        public string FlightIndicator { get; set; }

        /// <summary>
        /// Object that holds the data on the individual legs of the flight ticket
        /// </summary>
        public IList<AirlineFlightLeg> FlightLegs { get; set; }

        /// <summary>
        /// Airline tracing number
        /// This field is used by the following payment products: cards
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// <list type="bullet">
        ///   <item><description>true = The ticket is an E-Ticket</description></item>
        ///   <item><description>false = the ticket is not an E-Ticket'</description></item>
        /// </list>
        /// </summary>
        [Obsolete("Deprecated")]
        public bool? IsETicket { get; set; }

        /// <summary>
        /// Indicates if the ticket is refundable or not.
        /// <list type="bullet">
        ///   <item><description>true - Restricted, the ticket is non-refundable</description></item>
        ///   <item><description>false - No restrictions, the ticket is (partially) refundable
        /// This field is used by the following payment products: 840</description></item>
        /// </list>
        /// </summary>
        public bool? IsRestrictedTicket { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// <list type="bullet">
        ///   <item><description>true - The payer is the ticket holder</description></item>
        ///   <item><description>false - The payer is not the ticket holder</description></item>
        /// </list>
        /// </summary>
        [Obsolete("This field is not used by any payment product  * true - The payer is the ticket holder  * false - The payer is not the ticket holder")]
        public bool? IsThirdParty { get; set; }

        /// <summary>
        /// This is the date of issue recorded in the airline system In a case of multiple issuances of the same ticket to a cardholder, you should use the last ticket date.
        /// Format: YYYYMMDD
        /// This field is used by the following payment products: cards, 840
        /// </summary>
        public string IssueDate { get; set; }

        /// <summary>
        /// Your ID of the customer in the context of the airline data
        /// This field is used by the following payment products: 840
        /// </summary>
        public string MerchantCustomerId { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// Name of the airline
        /// </summary>
        [Obsolete("This field is not used by any payment product Name of the airline")]
        public string Name { get; set; }

        /// <summary>
        /// Deprecated: Use passengers instead
        /// Name of passenger
        /// </summary>
        [Obsolete("Use passengers instead Name of passenger")]
        public string PassengerName { get; set; }

        /// <summary>
        /// Object that holds the data on the individual passengers
        /// This field is used by the following payment products: cards, 840
        /// </summary>
        public IList<AirlinePassenger> Passengers { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// Place of issue
        /// For sales in the US the last two characters (pos 14-15) must be the US state code.
        /// </summary>
        [Obsolete("This field is not used by any payment product Place of issue For sales in the US the last two characters (pos 14-15) must be the US state code.")]
        public string PlaceOfIssue { get; set; }

        /// <summary>
        /// <i><b>Deprecated</b></i>. Use passengers instead.
        /// </summary>
        [Obsolete("Use passengers instead.")]
        public string Pnr { get; set; }

        /// <summary>
        /// IATA point of sale name
        /// This field is used by the following payment products: 840
        /// </summary>
        public string PointOfSale { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// City code of the point of sale
        /// </summary>
        [Obsolete("This field is not used by any payment product City code of the point of sale")]
        public string PosCityCode { get; set; }

        /// <summary>
        /// Three-letter ISO currency code representing the currency in which ticket purchase amount is expressed.
        /// </summary>
        public string TicketCurrency { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// Delivery method of the ticket
        /// </summary>
        [Obsolete("This field is not used by any payment product Delivery method of the ticket")]
        public string TicketDeliveryMethod { get; set; }

        /// <summary>
        /// The ticket or document number contains:
        /// <list type="bullet">
        ///   <item><description>Airline code: 3-digit airline code number</description></item>
        ///   <item><description>Form code: A maximum of 3 digits indicating the type of document, the source of issue and the number of coupons it contains</description></item>
        ///   <item><description>Serial number: A maximum of 8 digits allocated on a sequential basis, provided that the total number of digits allocated to the form code and serial number shall not exceed ten</description></item>
        ///   <item><description>TICKETNUMBER can be replaced with PNR if the ticket number is unavailable
        /// This field is used by the following payment products: cards, 840</description></item>
        /// </list>
        /// </summary>
        public string TicketNumber { get; set; }

        /// <summary>
        /// Total fare for all legs on the ticket, excluding taxes and fees. If multiple tickets are purchased, this is the total fare for all tickets
        /// This field is used by the following payment products: 840
        /// </summary>
        public int? TotalFare { get; set; }

        /// <summary>
        /// Total fee for all legs on the ticket. If multiple tickets are purchased, this is the total fee for all tickets
        /// This field is used by the following payment products: 840
        /// </summary>
        public int? TotalFee { get; set; }

        /// <summary>
        /// Total taxes for all legs on the ticket. If multiple tickets are purchased, this is the total taxes for all tickets
        /// This field is used by the following payment products: 840
        /// </summary>
        public int? TotalTaxes { get; set; }

        /// <summary>
        /// Name of the travel agency issuing the ticket. For direct airline integration, leave this property blank
        /// This field is used by the following payment products: 840
        /// </summary>
        public string TravelAgencyName { get; set; }
    }
}

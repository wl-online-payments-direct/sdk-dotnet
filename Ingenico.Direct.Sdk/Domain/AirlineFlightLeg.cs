/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class AirlineFlightLeg
    {
        /// <summary>
        /// Reservation Booking Designator<para />
        /// </summary>
        public string AirlineClass { get; set; } = null;

        /// <summary>
        /// Arrival airport/city code<para />
        /// </summary>
        public string ArrivalAirport { get; set; } = null;

        /// <summary>
        /// The arrival time in the local time zone<para />
        /// Format: HH:MM<para />
        /// </summary>
        public string ArrivalTime { get; set; } = null;

        /// <summary>
        /// IATA carrier code<para />
        /// </summary>
        public string CarrierCode { get; set; } = null;

        /// <summary>
        /// Identifying number of a ticket issued to a passenger in conjunction with this ticket and that constitutes a single contract of carriage<para />
        /// </summary>
        public string ConjunctionTicket { get; set; } = null;

        /// <summary>
        /// The coupon number associated with this leg of the trip. A ticket can contain several legs of travel, and each leg of travel requires a separate coupon<para />
        /// </summary>
        public string CouponNumber { get; set; } = null;

        /// <summary>
        /// Date of the leg<para />
        /// Format: YYYYMMDD<para />
        /// </summary>
        public string Date { get; set; } = null;

        /// <summary>
        /// The departure time in the local time at the departure airport<para />
        /// Format: HH:MM<para />
        /// </summary>
        public string DepartureTime { get; set; } = null;

        /// <summary>
        /// An endorsement can be an agency-added notation or a mandatory government required notation, such as value-added tax. A restriction is a limitation based on the type of fare, such as a ticket with a 3-day minimum stay<para />
        /// </summary>
        public string EndorsementOrRestriction { get; set; } = null;

        /// <summary>
        /// New ticket number that is issued when a ticket is exchanged<para />
        /// </summary>
        public string ExchangeTicket { get; set; } = null;

        /// <summary>
        /// Fare of this leg<para />
        /// </summary>
        public string Fare { get; set; } = null;

        /// <summary>
        /// Fare Basis/Ticket Designator<para />
        /// </summary>
        public string FareBasis { get; set; } = null;

        /// <summary>
        /// Fee for this leg of the trip<para />
        /// </summary>
        public int? Fee { get; set; } = null;

        /// <summary>
        /// The flight number assigned by the airline carrier with no leading spaces<para />
        /// Should be a numeric string<para />
        /// </summary>
        public string FlightNumber { get; set; } = null;

        /// <summary>
        /// Sequence number of the flight leg<para />
        /// </summary>
        public int? Number { get; set; } = null;

        /// <summary>
        /// Origin airport/city code<para />
        /// </summary>
        public string OriginAirport { get; set; } = null;

        /// <summary>
        /// PassengerClass if this leg<para />
        /// </summary>
        public string PassengerClass { get; set; } = null;

        /// <summary>
        /// Possible values are:<para />
        ///  * permitted = Stopover permitted<para />
        ///  * non-permitted = Stopover not permitted<para />
        /// </summary>
        public string StopoverCode { get; set; } = null;

        /// <summary>
        /// Taxes for this leg of the trip<para />
        /// </summary>
        public int? Taxes { get; set; } = null;
    }
}

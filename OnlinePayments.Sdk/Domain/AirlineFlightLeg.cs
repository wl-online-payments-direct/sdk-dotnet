/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class AirlineFlightLeg
    {
        /// <summary>
        /// Reservation Booking Designator
        /// This field is used by the following payment products: cards
        /// </summary>
        public string AirlineClass { get; set; }

        /// <summary>
        /// Arrival airport/city code
        /// This field is used by the following payment products: 840
        /// </summary>
        public string ArrivalAirport { get; set; }

        /// <summary>
        /// The arrival time in the local time zone
        /// Format: HH:MM
        /// This field is used by the following payment products: 840
        /// </summary>
        public string ArrivalTime { get; set; }

        /// <summary>
        /// IATA carrier code
        /// This field is used by the following payment products: cards, 840
        /// </summary>
        public string CarrierCode { get; set; }

        /// <summary>
        /// Identifying number of a ticket issued to a passenger in conjunction with this ticket and that constitutes a single contract of carriage
        /// This field is used by the following payment products: 840
        /// </summary>
        public string ConjunctionTicket { get; set; }

        /// <summary>
        /// The coupon number associated with this leg of the trip. A ticket can contain several legs of travel, and each leg of travel requires a separate coupon
        /// This field is used by the following payment products: 840
        /// </summary>
        public string CouponNumber { get; set; }

        /// <summary>
        /// Date of the leg
        /// Format: YYYYMMDD
        /// This field is used by the following payment products: cards, 840
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// The departure time in the local time at the departure airport
        /// Format: HH:MM
        /// This field is used by the following payment products: 840
        /// </summary>
        public string DepartureTime { get; set; }

        /// <summary>
        /// An endorsement can be an agency-added notation or a mandatory government required notation, such as value-added tax. A restriction is a limitation based on the type of fare, such as a ticket with a 3-day minimum stay
        /// This field is used by the following payment products: 840
        /// </summary>
        public string EndorsementOrRestriction { get; set; }

        /// <summary>
        /// New ticket number that is issued when a ticket is exchanged
        /// This field is used by the following payment products: 840
        /// </summary>
        public string ExchangeTicket { get; set; }

        /// <summary>
        /// Deprecated: Use legFare instead.
        /// Fare of this leg
        /// </summary>
        [Obsolete("Use legFare instead. Fare of this leg")]
        public string Fare { get; set; }

        /// <summary>
        /// Fare Basis/Ticket Designator
        /// This field is used by the following payment products: 840
        /// </summary>
        public string FareBasis { get; set; }

        /// <summary>
        /// Fee for this leg of the trip
        /// This field is used by the following payment products: 840
        /// </summary>
        public int? Fee { get; set; }

        /// <summary>
        /// The flight number of the current leg.
        /// This field is used by the following payment products: 840
        /// </summary>
        public string FlightCode { get; set; }

        /// <summary>
        /// The flight number assigned by the airline carrier with no leading spaces
        /// Should be a numeric string
        /// This field is used by the following payment products: cards, 840
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// Fee for this leg of the trip
        /// This field is used by the following payment products: 840
        /// </summary>
        public int? LegFare { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// Sequence number of the flight leg
        /// </summary>
        [Obsolete("This field is not used by any payment product Sequence number of the flight leg")]
        public int? Number { get; set; }

        /// <summary>
        /// Origin airport/city code
        /// This field is used by the following payment products: cards, 840
        /// </summary>
        public string OriginAirport { get; set; }

        /// <summary>
        /// PassengerClass if this leg
        /// This field is used by the following payment products: 840
        /// </summary>
        public string PassengerClass { get; set; }

        /// <summary>
        /// Possible values are:
        /// <list type="bullet">
        ///   <item><description>permitted = Stopover permitted</description></item>
        ///   <item><description>non-permitted = Stopover not permitted
        /// This field is used by the following payment products: cards, 840</description></item>
        /// </list>
        /// </summary>
        public string StopoverCode { get; set; }

        /// <summary>
        /// Taxes for this leg of the trip
        /// This field is used by the following payment products: 840
        /// </summary>
        public int? Taxes { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithAirlineClass(string value)
        {
            AirlineClass = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithArrivalAirport(string value)
        {
            ArrivalAirport = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithArrivalTime(string value)
        {
            ArrivalTime = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithCarrierCode(string value)
        {
            CarrierCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithConjunctionTicket(string value)
        {
            ConjunctionTicket = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithCouponNumber(string value)
        {
            CouponNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithDate(string value)
        {
            Date = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithDepartureTime(string value)
        {
            DepartureTime = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithEndorsementOrRestriction(string value)
        {
            EndorsementOrRestriction = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithExchangeTicket(string value)
        {
            ExchangeTicket = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        [Obsolete("Use legFare instead. Fare of this leg")]
        public AirlineFlightLeg WithFare(string value)
        {
            Fare = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithFareBasis(string value)
        {
            FareBasis = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithFee(int? value)
        {
            Fee = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithFlightCode(string value)
        {
            FlightCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithFlightNumber(string value)
        {
            FlightNumber = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithLegFare(int? value)
        {
            LegFare = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        [Obsolete("This field is not used by any payment product Sequence number of the flight leg")]
        public AirlineFlightLeg WithNumber(int? value)
        {
            Number = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithOriginAirport(string value)
        {
            OriginAirport = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithPassengerClass(string value)
        {
            PassengerClass = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithStopoverCode(string value)
        {
            StopoverCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public AirlineFlightLeg WithTaxes(int? value)
        {
            Taxes = value;
            return this;
        }
    }
}

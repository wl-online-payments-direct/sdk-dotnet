/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Shipping
    {
        /// <summary>
        /// Object containing address information<para />
        /// </summary>
        public AddressPersonal Address { get; set; } = null;

        /// <summary>
        /// Indicates shipping method chosen for the transaction. Possible values:<para />
        ///  * same-as-billing = the shipping address is the same as the billing address<para />
        ///  * another-verified-address-on-file-with-merchant = the address used for shipping is another verified address of the customer that is on file with you<para />
        ///  * different-than-billing = shipping address is different from the billing address<para />
        ///  * ship-to-store = goods are shipped to a store (shipping address = store address)<para />
        ///  * digital-goods = electronic delivery of digital goods<para />
        ///  * travel-and-event-tickets-not-shipped = travel and/or event tickets that are not shipped<para />
        ///  * other = other means of delivery<para />
        /// </summary>
        public string AddressIndicator { get; set; } = null;

        /// <summary>
        /// Email address linked to the shipping<para />
        /// </summary>
        public string EmailAddress { get; set; } = null;

        /// <summary>
        /// Date (YYYYMMDD) when the shipping details for this transaction were first used.<para />
        /// </summary>
        public string FirstUsageDate { get; set; } = null;

        /// <summary>
        /// Indicator if this shipping address is used for the first time to ship an order<para />
        /// <para />
        /// true = the shipping details are used for the first time with this transaction<para />
        /// <para />
        /// false = the shipping details have been used for other transactions in the past<para />
        /// </summary>
        public bool? IsFirstUsage { get; set; } = null;

        /// <summary>
        /// Object containing information regarding shipping method<para />
        /// </summary>
        public ShippingMethod Method { get; set; } = null;

        /// <summary>
        /// Cost associated with the shipping of the order.<para />
        /// </summary>
        public long? ShippingCost { get; set; } = null;

        /// <summary>
        /// Tax amount of the shipping cost.<para />
        /// </summary>
        public long? ShippingCostTax { get; set; } = null;

        /// <summary>
        /// Indicates the merchandise delivery timeframe. Possible values:<para />
        ///  * electronic = For electronic delivery (services or digital goods)<para />
        ///  * same-day = For same day deliveries<para />
        ///  * overnight = For overnight deliveries<para />
        ///  * 2-day-or-more = For two day or more delivery time<para />
        /// </summary>
        public string Type { get; set; } = null;
    }
}

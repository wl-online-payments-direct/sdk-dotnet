/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardEssentials
    {
        /// <summary>
        /// The first digits of the credit card number from left to right with a minimum of 6 digits.<para />
        /// </summary>
        public string Bin { get; set; } = null;

        /// <summary>
        /// The masked credit/debit card number<para />
        /// </summary>
        public string CardNumber { get; set; } = null;

        /// <summary>
        /// The card's type as categorised by the payment method. Possible values are:<para />
        ///   * Credit<para />
        ///   * Debit<para />
        ///   * Prepaid<para />
        /// </summary>
        public string CardType { get; set; } = null;

        /// <summary>
        /// ISO 3166-1 alpha-2 country code<para />
        /// </summary>
        public string CountryCode { get; set; } = null;

        /// <summary>
        /// Expiry date of the card <para />
        ///  Format: MMYY<para />
        /// </summary>
        public string ExpiryDate { get; set; } = null;
    }
}

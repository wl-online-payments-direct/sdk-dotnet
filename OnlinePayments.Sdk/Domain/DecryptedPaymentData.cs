/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DecryptedPaymentData
    {
        /// <summary>
        /// Card holder's name on the card. <para />
        ///  * For Apple Pay, maps to the cardholderName property in the encrypted payment data.<para />
        /// </summary>
        public string CardholderName { get; set; } = null;

        /// <summary>
        /// The 3D secure online payment cryptogram.<para />
        /// * For Apple Pay, maps to the paymentData.onlinePaymentCryptogram property in the encrypted payment data.<para />
        /// * For Google Pay, maps to the paymentMethodDetails.3dsCryptogram property in the encrypted payment data.<para />
        /// Not allowed for Google Pay if the paymentMethod is CARD.<para />
        /// </summary>
        public string Cryptogram { get; set; } = null;

        /// <summary>
        /// The device specific PAN. <para />
        ///  * For Apple Pay, maps to the applicationPrimaryAccountNumber property in the encrypted payment.<para />
        /// </summary>
        public string Dpan { get; set; } = null;

        /// <summary>
        /// Electronic Commerce Indicator. <para />
        ///  * For Apple Pay, maps to the paymentData.eciIndicator property in the encrypted payment data.<para />
        /// </summary>
        public int? Eci { get; set; } = null;

        /// <summary>
        /// Expiry date of the card Format: MMYY. <para />
        ///  * For Apple Pay, maps to the applicationExpirationDate property in the encrypted payment data. This property is formatted as YYMMDD, so this needs to be converted to get a correctly formatted expiry date<para />
        /// </summary>
        public string ExpiryDate { get; set; } = null;
    }
}

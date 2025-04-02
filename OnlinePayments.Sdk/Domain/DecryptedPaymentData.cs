/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DecryptedPaymentData
    {
        /// <summary>
        /// Card holder's name on the card.
        /// <list type="bullet">
        ///   <item><description>For Apple Pay, maps to the cardholderName property in the encrypted payment data.</description></item>
        /// </list>
        /// </summary>
        public string CardholderName { get; set; }

        /// <summary>
        /// The 3D secure online payment cryptogram.
        /// <list type="bullet">
        ///   <item><description>For Apple Pay, maps to the paymentData.onlinePaymentCryptogram property in the encrypted payment data.</description></item>
        ///   <item><description>For Google Pay, maps to the paymentMethodDetails.3dsCryptogram property in the encrypted payment data.
        /// Not allowed for Google Pay if the paymentMethod is CARD.</description></item>
        /// </list>
        /// </summary>
        public string Cryptogram { get; set; }

        /// <summary>
        /// The device specific PAN.
        /// <list type="bullet">
        ///   <item><description>For Apple Pay, maps to the applicationPrimaryAccountNumber property in the encrypted payment.</description></item>
        /// </list>
        /// </summary>
        public string Dpan { get; set; }

        /// <summary>
        /// Electronic Commerce Indicator.
        /// <list type="bullet">
        ///   <item><description>For Apple Pay, maps to the paymentData.eciIndicator property in the encrypted payment data.</description></item>
        /// </list>
        /// </summary>
        public int? Eci { get; set; }

        /// <summary>
        /// Expiry date of the card Format: MMYY.
        /// <list type="bullet">
        ///   <item><description>For Apple Pay, maps to the applicationExpirationDate property in the encrypted payment data. This property is formatted as YYMMDD, so this needs to be converted to get a correctly formatted expiry date</description></item>
        /// </list>
        /// </summary>
        public string ExpiryDate { get; set; }
    }
}

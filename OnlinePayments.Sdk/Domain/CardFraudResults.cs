/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardFraudResults
    {
        /// <summary>
        ///  Result of the Address Verification Service checks. Possible values are: <para />
        ///  * A - Address (Street) matches, Zip does not <para />
        ///  * B - Street address match for international transactions—Postal code not verified due to incompatible formats <para />
        ///  * C - Street address and postal code not verified for international transaction due to incompatible formats <para />
        ///  * D - Street address and postal code match for international transaction, cardholder name is incorrect <para />
        ///  * E - AVS error <para />
        ///  * F - Address does match and five digit ZIP code does match (UK only) <para />
        ///  * G - Address information is unavailable; international transaction; non-AVS participant <para />
        ///  * H - Billing address and postal code match, cardholder name is incorrect (Amex) <para />
        ///  * I - Address information not verified for international transaction <para />
        ///  * K - Cardholder name matches (Amex) <para />
        ///  * L - Cardholder name and postal code match (Amex) <para />
        ///  * M - Cardholder name, street address, and postal code match for international transaction <para />
        ///  * N - No Match on Address (Street) or Zip <para />
        ///  * O - Cardholder name and address match (Amex) <para />
        ///  * P - Postal codes match for international transaction—Street address not verified due to incompatible formats <para />
        ///  * Q - Billing address matches, cardholder is incorrect (Amex) <para />
        ///  * R - Retry, System unavailable or Timed out <para />
        ///  * S - Service not supported by issuer <para />
        ///  * U - Address information is unavailable <para />
        ///  * W - 9 digit Zip matches, Address (Street) does not <para />
        ///  * X - Exact AVS Match <para />
        ///  * Y - Address (Street) and 5 digit Zip match <para />
        ///  * Z - 5 digit Zip matches, Address (Street) does not <para />
        ///  * 0 - No service available<para />
        /// </summary>
        public string AvsResult { get; set; } = null;

        /// <summary>
        ///  Result of the Card Verification Value checks. Possible values are: <para />
        ///  * M - CVV check performed and valid value <para />
        ///  * N - CVV checked and no match <para />
        ///  * P - CVV check not performed, not requested <para />
        ///  * S - Cardholder claims no CVV code on card, issuer states CVV-code should be on card <para />
        ///  * U - Issuer not certified for CVV2 <para />
        ///  * Y - Server provider did not respond <para />
        ///  * 0 - No service available<para />
        /// </summary>
        public string CvvResult { get; set; } = null;

        /// <summary>
        /// Resulting advice of the fraud prevention checks. Possible values are:<para />
        /// * accepted - Based on the checks performed the transaction can be accepted<para />
        /// * challenged - Based on the checks performed the transaction should be manually reviewed<para />
        /// * denied - Based on the checks performed the transaction should be rejected<para />
        /// * no-advice - No fraud check was requested/performed<para />
        /// * error - The fraud check resulted an error. Note that the fraud check was thus not performed.<para />
        /// </summary>
        public string FraudServiceResult { get; set; } = null;
    }
}

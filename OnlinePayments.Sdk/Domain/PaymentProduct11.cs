/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct11
    {
        /// <summary>
        /// The BIC is the Bank Identifier Code, also known as SWIFT code, used to identify banks internationally.
        /// </summary>
        public string PaymentBIC { get; set; }

        /// <summary>
        /// The beneficiary of the payment
        /// </summary>
        public string PaymentBeneficiary { get; set; }

        /// <summary>
        /// The IBAN is the International Bank Account Number. It is an internationally agreed format for the BBAN and includes the ISO country code and two check digits.
        /// </summary>
        public string PaymentIBAN { get; set; }

        /// <summary>
        /// The reference for the payment
        /// </summary>
        public string PaymentReference { get; set; }

        /// <summary>
        /// This field provides a Base64-encoded string representing a standardized payment QR code. The payload contains the complete transaction initiation data, including Service Tag, Version, Character Set, Identification, BIC, Beneficiary Name, IBAN, Amount, and Communication reference.
        /// </summary>
        public string QrCode { get; set; }
    }
}

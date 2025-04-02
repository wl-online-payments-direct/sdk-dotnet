/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProduct5001SpecificOutput
    {
        /// <summary>
        /// The account number used for this transaction
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// The reference returned by redsys to identify the transaction
        /// </summary>
        public string AuthorisationCode { get; set; }

        /// <summary>
        /// Determines the Fraud liability. Possible values are:
        /// <list type="bullet">
        ///   <item><description>issuer - Fraud liability shifts to the issuer (eq. exemption accepted)</description></item>
        ///   <item><description>merchant - Fraud liability with the merchant
        /// Note: When not filled in, Fraud liability is not applicable for the current transaction.</description></item>
        /// </list>
        /// </summary>
        public string Liability { get; set; }

        /// <summary>
        /// The mobile phone number used for this transaction
        /// </summary>
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// The reference returned by redsys to identify the operation
        /// </summary>
        public string OperationCode { get; set; }
    }
}

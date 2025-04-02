/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DccCardSource
    {
        public CardInfo Card { get; set; }

        /// <summary>
        /// Data that was encrypted client-side that contains all customer-entered data elements, such as card data.
        /// </summary>
        public string EncryptedCustomerInput { get; set; }

        /// <summary>
        /// An Id of a hosted tokenization session
        /// </summary>
        public string HostedTokenizationId { get; set; }

        /// <summary>
        /// An identifier that represents card details that have previously been stored
        /// </summary>
        public string Token { get; set; }
    }
}

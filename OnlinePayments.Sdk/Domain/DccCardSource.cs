/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DccCardSource
    {
        public CardInfo Card { get; set; } = null;

        /// <summary>
        /// Data that was encrypted client-side that contains all customer-entered data elements, such as card data.<para />
        /// </summary>
        public string EncryptedCustomerInput { get; set; } = null;

        /// <summary>
        /// An Id of a hosted tokenization session<para />
        /// </summary>
        public string HostedTokenizationId { get; set; } = null;

        /// <summary>
        /// An identifier that represents card details that have previously been stored<para />
        /// </summary>
        public string Token { get; set; } = null;
    }
}

/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardSource
    {
        /// <summary>
        /// An object containing card number and payment product id, which is used to determine surcharge product type<para />
        /// </summary>
        public SurchargeCalculationCard Card { get; set; } = null;

        /// <summary>
        /// Data that was encrypted client side containing all customer entered data elements like card data.<para />
        /// </summary>
        public string EncryptedCustomerInput { get; set; } = null;

        /// <summary>
        /// An Id of a hosted tokenization session<para />
        /// </summary>
        public string HostedTokenizationId { get; set; } = null;

        /// <summary>
        /// An identifier that represents card details that have been previously stored<para />
        /// </summary>
        public string Token { get; set; } = null;
    }
}

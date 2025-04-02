/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardSource
    {
        /// <summary>
        /// An object containing card number and payment product id, which is used to determine surcharge product type
        /// </summary>
        public SurchargeCalculationCard Card { get; set; }

        /// <summary>
        /// Data that was encrypted client side containing all customer entered data elements like card data.
        /// </summary>
        public string EncryptedCustomerInput { get; set; }

        /// <summary>
        /// An Id of a hosted tokenization session
        /// </summary>
        public string HostedTokenizationId { get; set; }

        /// <summary>
        /// An identifier that represents card details that have been previously stored
        /// </summary>
        public string Token { get; set; }
    }
}

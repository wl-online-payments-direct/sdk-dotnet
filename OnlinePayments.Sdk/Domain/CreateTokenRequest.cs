/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreateTokenRequest
    {
        /// <summary>
        /// Object containing the token details for a card
        /// </summary>
        public TokenCardSpecificInput Card { get; set; }

        /// <summary>
        /// Data that was encrypted client side containing all customer entered data elements like card data.
        /// Note: Because this data can only be submitted once to our system and contains encrypted card data you should not store it. As the data was captured within the context of a client session you also need to submit it to us before the session has expired.
        /// </summary>
        public string EncryptedCustomerInput { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}

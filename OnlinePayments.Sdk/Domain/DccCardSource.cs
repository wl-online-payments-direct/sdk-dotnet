/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class DccCardSource
    {
        public CardInfo Card { get; set; }

        /// <summary>
        /// Data that was encrypted client side containing all customer entered data elements like card data.
        /// Note: Because this data can only be submitted once to our system and contains encrypted card data you should not store it. As the data was captured within the context of a client session you also need to submit it to us before the session has expired.
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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccCardSource WithCard(CardInfo value)
        {
            Card = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccCardSource WithEncryptedCustomerInput(string value)
        {
            EncryptedCustomerInput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccCardSource WithHostedTokenizationId(string value)
        {
            HostedTokenizationId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public DccCardSource WithToken(string value)
        {
            Token = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
using Newtonsoft.Json;

namespace OnlinePayments.Sdk.Domain
{
    public class RedirectData
    {
        /// <summary>
        /// A Message Authentication Code (MAC) is used to authenticate the redirection back to merchant after the payment
        /// </summary>
        [JsonProperty(PropertyName = "RETURNMAC")]
        public string RETURNMAC { get; set; }

        /// <summary>
        /// The URL that the customer should be redirected to. Be sure to redirect using the GET method
        /// </summary>
        public string RedirectURL { get; set; }
    }
}

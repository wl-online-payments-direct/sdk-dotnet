/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
using Newtonsoft.Json;

namespace Ingenico.Direct.Sdk.Domain
{
    public class RedirectData
    {
        [JsonProperty(PropertyName = "RETURNMAC")]
        /// <summary>
        /// A Message Authentication Code (MAC) is used to authenticate the redirection back to merchant after the payment<para />
        /// </summary>
        public string RETURNMAC { get; set; } = null;

        /// <summary>
        /// The URL that the customer should be redirected to. Be sure to redirect using the GET method<para />
        /// </summary>
        public string RedirectURL { get; set; } = null;
    }
}

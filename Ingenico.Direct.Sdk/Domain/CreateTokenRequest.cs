/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CreateTokenRequest
    {
        /// <summary>
        /// Object containing the token details for a card<para />
        /// </summary>
        public TokenCardSpecificInput Card { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see [payment products](https://support.direct.ingenico.com/documentation/api/reference/index.html#tag/Products) for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}

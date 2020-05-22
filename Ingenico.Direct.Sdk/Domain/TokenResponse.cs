/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class TokenResponse
    {
        public TokenCard Card { get; set; } = null;

        public TokenEWallet EWallet { get; set; } = null;

        public string Id { get; set; } = null;

        public int? PaymentProductId { get; set; } = null;
    }
}

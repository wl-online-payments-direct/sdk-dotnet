/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CreatedTokenResponse
    {
        public CardWithoutCvv Card { get; set; } = null;

        public bool? IsNewToken { get; set; } = null;

        public string Token { get; set; } = null;
    }
}

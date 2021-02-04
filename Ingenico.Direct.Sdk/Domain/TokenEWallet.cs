/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class TokenEWallet
    {
        /// <summary>
        /// An alias for the token. This can be used to visually represent the token.<para />
        /// </summary>
        public string Alias { get; set; } = null;

        public CustomerToken Customer { get; set; } = null;
    }
}

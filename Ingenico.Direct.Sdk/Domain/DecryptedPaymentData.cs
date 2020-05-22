/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class DecryptedPaymentData
    {
        public string CardholderName { get; set; } = null;

        public string Cryptogram { get; set; } = null;

        public string Dpan { get; set; } = null;

        public int? Eci { get; set; } = null;

        public string ExpiryDate { get; set; } = null;
    }
}

/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CardPaymentMethodSpecificOutput
    {
        public string AuthorisationCode { get; set; } = null;

        public CardEssentials Card { get; set; } = null;

        public CardFraudResults FraudResults { get; set; } = null;

        public string InitialSchemeTransactionId { get; set; } = null;

        public int? PaymentProductId { get; set; } = null;

        public ThreeDSecureResults ThreeDSecureResults { get; set; } = null;

        public string Token { get; set; } = null;
    }
}

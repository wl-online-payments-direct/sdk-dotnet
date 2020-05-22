/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CardPaymentMethodSpecificInput
    {
        public string AuthorizationMode { get; set; } = null;

        public Card Card { get; set; } = null;

        public string InitialSchemeTransactionId { get; set; } = null;

        public bool? IsRecurring { get; set; } = null;

        public int? PaymentProductId { get; set; } = null;

        public CardRecurrenceDetails Recurring { get; set; } = null;

        public string ReturnUrl { get; set; } = null;

        public bool? SkipAuthentication { get; set; } = null;

        public ThreeDSecure ThreeDSecure { get; set; } = null;

        public string Token { get; set; } = null;

        public bool? Tokenize { get; set; } = null;

        public string TransactionChannel { get; set; } = null;

        public string UnscheduledCardOnFileRequestor { get; set; } = null;

        public string UnscheduledCardOnFileSequenceIndicator { get; set; } = null;
    }
}

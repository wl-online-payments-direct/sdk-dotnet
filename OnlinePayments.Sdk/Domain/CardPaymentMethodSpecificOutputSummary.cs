/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CardPaymentMethodSpecificOutputSummary
    {
        /// <summary>
        /// Card details
        /// </summary>
        public CardPaymentMethodSpecificOutputSummaryCard Card { get; set; }

        /// <summary>
        /// ID of the token. This property is populated when the payment was done with a token or when the payment was tokenized.
        /// </summary>
        public string Token { get; set; }
    }
}

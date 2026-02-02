/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CrmToken
    {
        /// <summary>
        /// A unique identifier that remains constant across different formats of the same card (whether used via wallets such as Apple Pay, Google Pay, etc., or the physical card), even if the tokenID may differ. The unique account identifier cannot be used to trigger a payment.
        /// </summary>
        public string UniqueAccountIdentifier { get; set; }

        /// <summary>
        /// A unique identifier for the card that was tokenized. This identifier remains the same for a given card, even if the tokenID may differ. The unique card identifier cannot be used to trigger a payment.
        /// </summary>
        public string UniqueCardIdentifier { get; set; }
    }
}

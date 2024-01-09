/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreditCardValidationRulesHostedTokenization
    {
        /// <summary>
        /// Determines whether the Card Verification Value must be provided for existing tokens. This option overrides the payment method configuration for the session.<para />
        /// </summary>
        public bool? CvvMandatoryForExistingToken { get; set; } = null;

        /// <summary>
        /// Determines whether the Card Verification Value must be provided for new tokens. This option overrides the payment method configuration for the session.<para />
        /// </summary>
        public bool? CvvMandatoryForNewToken { get; set; } = null;
    }
}

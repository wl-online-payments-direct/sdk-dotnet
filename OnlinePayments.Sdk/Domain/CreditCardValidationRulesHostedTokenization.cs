/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CreditCardValidationRulesHostedTokenization
    {
        /// <summary>
        /// Determines whether the Card Verification Value must be provided for existing tokens. This option overrides the payment method configuration for the session.
        /// </summary>
        public bool? CvvMandatoryForExistingToken { get; set; }

        /// <summary>
        /// Determines whether the Card Verification Value must be provided for new tokens. This option overrides the payment method configuration for the session.
        /// </summary>
        public bool? CvvMandatoryForNewToken { get; set; }
    }
}

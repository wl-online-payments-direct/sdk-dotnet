/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RefundCardMethodSpecificOutput
    {
        /// <summary>
        /// This object contains the acceptance information for the card payment authorization.
        /// </summary>
        public Acceptance Acceptance { get; set; }

        /// <summary>
        /// Card Authorization code as returned by the acquirer
        /// </summary>
        public string AuthorisationCode { get; set; }

        public CurrencyConversion CurrencyConversion { get; set; }

        /// <summary>
        /// Instructions for reattempting a declined authorization. Provided only in case of declined authorization, for those acquirers that may respond with explicit instructions regarding potential reattempt processing.
        /// </summary>
        public ReattemptInstructions ReattemptInstructions { get; set; }

        public long? TotalAmountPaid { get; set; }

        public long? TotalAmountRefunded { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithAcceptance(Acceptance value)
        {
            Acceptance = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithAuthorisationCode(string value)
        {
            AuthorisationCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithCurrencyConversion(CurrencyConversion value)
        {
            CurrencyConversion = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithReattemptInstructions(ReattemptInstructions value)
        {
            ReattemptInstructions = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithTotalAmountPaid(long? value)
        {
            TotalAmountPaid = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public RefundCardMethodSpecificOutput WithTotalAmountRefunded(long? value)
        {
            TotalAmountRefunded = value;
            return this;
        }
    }
}

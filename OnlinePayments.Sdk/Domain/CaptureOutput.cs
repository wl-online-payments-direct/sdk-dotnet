/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CaptureOutput
    {
        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AcquiredAmount { get; set; } = null;

        /// <summary>
        /// Object containing amount and ISO currency code attributes<para />
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; } = null;

        /// <summary>
        /// Amount that has been paid. This is deprecated. Use acquiredAmount instead.<para />
        /// </summary>
        public long? AmountPaid { get; set; } = null;

        /// <summary>
        /// Object containing the card payment method details<para />
        /// </summary>
        public CardPaymentMethodSpecificOutput CardPaymentMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// It allows you to store additional parameters for the transaction in the format you prefer (e.g.-> key-value query string, JSON, etc.) These parameters are then echoed back to you in API GET calls and Webhook notifications. This field must not contain any personal data.<para />
        /// </summary>
        public string MerchantParameters { get; set; } = null;

        /// <summary>
        /// Object containing the mobile payment method details<para />
        /// </summary>
        public MobilePaymentMethodSpecificOutput MobilePaymentMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Payment method identifier used by the our payment engine.<para />
        /// </summary>
        public string PaymentMethod { get; set; } = null;

        /// <summary>
        /// Object containing the redirect payment product details<para />
        /// </summary>
        public RedirectPaymentMethodSpecificOutput RedirectPaymentMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// <para />
        /// Deprecated: Use OperationReferences instead.<para />
        /// </summary>
        public PaymentReferences References { get; set; } = null;

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction<para />
        /// </summary>
        public OperationPaymentReferences OperationReferences { get; set; } = null;

        /// <summary>
        /// Object containing the SEPA direct debit details<para />
        /// </summary>
        public SepaDirectDebitPaymentMethodSpecificOutput SepaDirectDebitPaymentMethodSpecificOutput { get; set; } = null;

        /// <summary>
        /// Object containing specific surcharging attributes applied to an order.<para />
        /// </summary>
        public SurchargeSpecificOutput SurchargeSpecificOutput { get; set; } = null;
    }
}
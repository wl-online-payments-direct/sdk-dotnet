/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class PaymentOutput
    {
        /// <summary>
        /// Amount that has been acquired by the Acquirer
        /// </summary>
        public AmountOfMoney AcquiredAmount { get; set; }

        /// <summary>
        /// Object containing amount and ISO currency code attributes
        /// </summary>
        public AmountOfMoney AmountOfMoney { get; set; }

        /// <summary>
        /// Amount that has been paid. This is deprecated. Use acquiredAmount instead.
        /// </summary>
        [Obsolete("Amount that has been paid. This is deprecated. Use acquiredAmount instead.")]
        public long? AmountPaid { get; set; }

        /// <summary>
        /// Object containing the card payment method details
        /// </summary>
        public CardPaymentMethodSpecificOutput CardPaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object containing the details of the customer
        /// </summary>
        public CustomerOutput Customer { get; set; }

        /// <summary>
        /// Object to apply a discount to the total basket by adding a discount line.
        /// </summary>
        public Discount Discount { get; set; }

        /// <summary>
        /// It allows you to store additional parameters for the transaction in the format you prefer (e.g.-&gt; key-value query string, JSON, etc.) These parameters are then echoed back to you in API GET calls and Webhook notifications. This field must not contain any personal data.
        /// </summary>
        public string MerchantParameters { get; set; }

        /// <summary>
        /// Object containing the mobile payment method details
        /// </summary>
        public MobilePaymentMethodSpecificOutput MobilePaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Payment method identifier used by the our payment engine.
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Object containing the redirect payment product details
        /// </summary>
        public RedirectPaymentMethodSpecificOutput RedirectPaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object that holds all reference properties that are linked to this transaction. <b>Deprecated for capture/refund</b>: Use operationReferences instead.
        /// </summary>
        public PaymentReferences References { get; set; }

        /// <summary>
        /// Object containing the SEPA direct debit details
        /// </summary>
        public SepaDirectDebitPaymentMethodSpecificOutput SepaDirectDebitPaymentMethodSpecificOutput { get; set; }

        /// <summary>
        /// Object containing specific surcharging attributes applied to an order.
        /// </summary>
        public SurchargeSpecificOutput SurchargeSpecificOutput { get; set; }

        /// <summary>
        /// It is the server-side processing date and time of the transaction.
        /// </summary>
        public DateTimeOffset? TransactionDate { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithAcquiredAmount(AmountOfMoney value)
        {
            AcquiredAmount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithAmountOfMoney(AmountOfMoney value)
        {
            AmountOfMoney = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        [Obsolete("Amount that has been paid. This is deprecated. Use acquiredAmount instead.")]
        public PaymentOutput WithAmountPaid(long? value)
        {
            AmountPaid = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithCardPaymentMethodSpecificOutput(CardPaymentMethodSpecificOutput value)
        {
            CardPaymentMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithCustomer(CustomerOutput value)
        {
            Customer = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithDiscount(Discount value)
        {
            Discount = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithMerchantParameters(string value)
        {
            MerchantParameters = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithMobilePaymentMethodSpecificOutput(MobilePaymentMethodSpecificOutput value)
        {
            MobilePaymentMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithPaymentMethod(string value)
        {
            PaymentMethod = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithRedirectPaymentMethodSpecificOutput(RedirectPaymentMethodSpecificOutput value)
        {
            RedirectPaymentMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithReferences(PaymentReferences value)
        {
            References = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithSepaDirectDebitPaymentMethodSpecificOutput(SepaDirectDebitPaymentMethodSpecificOutput value)
        {
            SepaDirectDebitPaymentMethodSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithSurchargeSpecificOutput(SurchargeSpecificOutput value)
        {
            SurchargeSpecificOutput = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentOutput WithTransactionDate(DateTimeOffset? value)
        {
            TransactionDate = value;
            return this;
        }
    }
}

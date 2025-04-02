/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class SubsequentCardPaymentMethodSpecificInput
    {
        /// <summary>
        /// Determines the type of the authorization that will be used. Allowed values:
        /// <list type="bullet">
        ///   <item><description>FINAL_AUTHORIZATION - The payment creation results in an authorization that is ready for capture. Final authorizations can't be reversed and need to be captured for the full amount within 7 days.</description></item>
        ///   <item><description>PRE_AUTHORIZATION - The payment creation results in a pre-authorization that is ready for capture. Pre-authortizations can be reversed and can be captured within 30 days. The capture amount can be lower than the authorized amount.</description></item>
        ///   <item><description>SALE - The payment creation results in an authorization that is already captured at the moment of approval.</description></item>
        /// </list>
        /// <p />
        /// Only used with some acquirers, ignored for acquirers that do not support this. In case the acquirer does not allow this to be specified the authorizationMode is 'unspecified', which behaves similar to a final authorization.
        /// </summary>
        public string AuthorizationMode { get; set; }

        /// <summary>
        /// This payment's ordinal number in the sequence of payments.  As the payments are numbered from 1 to the totalNumberOfPayments provided at initialization of the sequence in the multiplePaymentInformation container, the allowed values for this field actually depend on whether the initial call to CreatePayment or CreateHostedCheckout led to a payment or not.
        /// <list type="bullet">
        ///   <item><description>if the initial call led to a payment, since it is implicitly numbered 1, then the allowed values for this field range from 2 to the totalNumberOfPayments.</description></item>
        ///   <item><description>if the initial call did not lead to a payment (e.g. this was a 0 amount operation for authentication), then the allowed values for this field range from 1 to the totalNumberOfPayments.</description></item>
        /// </list>
        /// </summary>
        public int? PaymentNumber { get; set; }

        /// <summary>
        /// Deprecated: This is the unique Scheme Reference Data from the initial transaction that was performed with a Strong Customer Authentication. In case this value is unknown, a Scheme Reference of an earlier transaction that was part of the same sequence can be used as a fall-back. Still, it is strongly advised to submit this value for any Merchant Initiated Transaction or any recurring transaction (hereby defined as &quot;Subsequent&quot;).
        /// </summary>
        [Obsolete("Deprecated")]
        public string SchemeReferenceData { get; set; }

        /// <summary>
        /// Determines the type of the subsequent that will be used. Allowed values:
        /// <list type="bullet">
        ///   <item><description>Recurring - Transactions processed at fixed, regular intervals not to exceed one year between Transactions, representing an agreement between a cardholder and a merchant to purchase goods or services provided over a period of time. Note that a recurring MIT transaction is initiated by the merchant (payee) not the customer (payer) and so is out of scope of PSD2. Recurring transactions that are in scope of PSD2 (and therefore may benefit from the recurring transaction exemption) are those that are customer (payer) initiates, e.g. standing orders set up from a bank account.</description></item>
        ///   <item><description>Unscheduled - A transaction using a stored credential for a fixed or variable amount that does not occur on a scheduled or regularly occurring transaction date, where the cardholder has provided consent for the merchant to initiate one or more future transactions which are not initiated by the cardholder. This transaction type is based on an agreement with the cardholder and is not to be confused with cardholder initiated transactions performed with stored credentials (CITs are in scope of PSD2 whereas UCOF transactions are MITs and thus out of scope).</description></item>
        ///   <item><description>Installment - Installment payments describe a single purchase of goods or services billed to a cardholder in multiple transactions over a period of time agreed by the cardholder and merchant.</description></item>
        ///   <item><description>NoShow - A No-show is a transaction where the merchant is enabled to charge for services which the cardholder entered into an agreement to purchase but did not meet the terms of the agreement.</description></item>
        ///   <item><description>DelayedCharge - A delayed charge is typically used in hotel, cruise lines and vehicle rental payment scenarios to perform a supplemental account charge after original services are rendered.</description></item>
        ///   <item><description>PartialShipment - I-P e-Commerce scenario whereby credentials have been stored to enable subsequent MITs per shipment. For this type of use case, PartialShipment is expected on both the initial CIT and eventual subsequent MITs to complete the order.</description></item>
        ///   <item><description>Resubmission - This is an event that occurs when the original purchase occurred, but the merchant was not able to get authorization at the time the goods or services were provided. This is only applicable to contactless transit transactions.</description></item>
        /// </list>
        /// </summary>
        public string SubsequentType { get; set; }

        /// <summary>
        /// Deprecated: ID of the token to use to create the payment.
        /// </summary>
        [Obsolete("ID of the token to use to create the payment.")]
        public string Token { get; set; }

        /// <summary>
        /// Indicates the channel via which the payment is created. Allowed values:
        /// <list type="bullet">
        ///   <item><description>ECOMMERCE - The transaction is a regular E-Commerce transaction.</description></item>
        ///   <item><description>MOTO - The transaction is a Mail Order/Telephone Order.</description></item>
        /// </list>
        /// <p />
        /// Defaults to ECOMMERCE.
        /// </summary>
        public string TransactionChannel { get; set; }
    }
}

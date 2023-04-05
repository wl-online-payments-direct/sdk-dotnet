/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SubsequentCardPaymentMethodSpecificInput
    {
        /// <summary>
        /// Determines the type of the authorization that will be used. Allowed values: <para />
        ///   * FINAL_AUTHORIZATION - The payment creation results in an authorization that is ready for capture. Final authorizations can't be reversed and need to be captured for the full amount within 7 days. <para />
        ///   * PRE_AUTHORIZATION - The payment creation results in a pre-authorization that is ready for capture. Pre-authortizations can be reversed and can be captured within 30 days. The capture amount can be lower than the authorized amount. <para />
        ///   * SALE - The payment creation results in an authorization that is already captured at the moment of approval. <para />
        /// <para />
        ///   Only used with some acquirers, ignored for acquirers that don't support this. In case the acquirer doesn't allow this to be specified the authorizationMode is 'unspecified', which behaves similar to a final authorization.<para />
        /// </summary>
        public string AuthorizationMode { get; set; } = null;

        /// <summary>
        /// This is the unique Scheme Reference Data from the initial transaction that was performed with a Strong Customer Authentication. In case this value is unknown, a Scheme Reference of an earlier transaction that was part of the same sequence can be used as a fall-back. Still, it is strongly advised to submit this value for any Merchant Initiated Transaction or any recurring transaction (hereby defined as "Subsequent").<para />
        /// </summary>
        public string SchemeReferenceData { get; set; } = null;

        /// <summary>
        /// Determines the type of the subsequent that will be used. Allowed values: <para />
        ///   * Recurring - Transactions processed at fixed, regular intervals not to exceed one year between Transactions, representing an agreement between a cardholder and a merchant to purchase goods or services provided over a period of time. Note that a recurring MIT transaction is initiated by the merchant (payee) not the customer (payer) and so is out of scope of PSD2. Recurring transactions that are in scope of PSD2 (and therefore may benefit from the recurring transaction exemption) are those that are customer (payer) initiates, e.g. standing orders set up from a bank account. <para />
        ///   * Unscheduled - A transaction using a stored credential for a fixed or variable amount that does not occur on a scheduled or regularly occurring transaction date, where the cardholder has provided consent for the merchant to initiate one or more future transactions which are not initiated by the cardholder. This transaction type is based on an agreement with the cardholder and is not to be confused with cardholder initiated transactions performed with stored credentials (CITs are in scope of PSD2 whereas UCOF transactions are MITs and thus out of scope). <para />
        ///   * Installment - Installment payments describe a single purchase of goods or services billed to a cardholder in multiple transactions over a period of time agreed by the cardholder and merchant. <para />
        ///   * NoShow - A No-show is a transaction where the merchant is enabled to charge for services which the cardholder entered into an agreement to purchase but did not meet the terms of the agreement.<para />
        ///   * DelayedCharge - A delayed charge is typically used in hotel, cruise lines and vehicle rental payment scenarios to perform a supplemental account charge after original services are rendered.<para />
        ///   * Reauthorisation - A Reauthorization is a purchase made after the original purchase and can reflect a number of specific conditions. Common scenarios include delayed/split shipments and extended stays/rentals.<para />
        ///   * Resubmission - This is an event that occurs when the original purchase occurred, but the merchant was not able to get authorization at the time the goods or services were provided. This is only applicable to contactless transit transactions.<para />
        /// </summary>
        public string SubsequentType { get; set; } = null;

        /// <summary>
        /// ID of the token to use to create the payment.<para />
        /// </summary>
        public string Token { get; set; } = null;

        /// <summary>
        /// Indicates the channel via which the payment is created. Allowed values:<para />
        ///   * ECOMMERCE - The transaction is a regular E-Commerce transaction.<para />
        ///   * MOTO - The transaction is a Mail Order/Telephone Order.<para />
        /// <para />
        ///   Defaults to ECOMMERCE.<para />
        /// </summary>
        public string TransactionChannel { get; set; } = null;
    }
}

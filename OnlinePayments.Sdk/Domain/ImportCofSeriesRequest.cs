/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ImportCofSeriesRequest
    {
        /// <summary>
        /// Object containing card details, which should be used if a tokenID is not provided.
        /// </summary>
        public CardDataWithoutCvv Card { get; set; }

        /// <summary>
        /// Three-letter ISO currency code representing the currency for the initial payment.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Object containing Network Token details
        /// </summary>
        public NetworkTokenData NetworkTokenData { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }

        /// <summary>
        /// Scheme Reference Data (SRD) used for scheme-level routing or identification.
        /// </summary>
        public string SchemeReferenceData { get; set; }

        /// <summary>
        /// ID of the token to use to create the payment series.
        /// </summary>
        public string TokenId { get; set; }

        /// <summary>
        /// The Transaction Link Identifier (TLID) of the original Consumer-Initiated Transaction (CIT).
        /// </summary>
        public string TransactionLinkIdentifier { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ImportCofSeriesRequest WithCard(CardDataWithoutCvv value)
        {
            Card = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ImportCofSeriesRequest WithCurrencyCode(string value)
        {
            CurrencyCode = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ImportCofSeriesRequest WithNetworkTokenData(NetworkTokenData value)
        {
            NetworkTokenData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ImportCofSeriesRequest WithPaymentProductId(int? value)
        {
            PaymentProductId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ImportCofSeriesRequest WithSchemeReferenceData(string value)
        {
            SchemeReferenceData = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ImportCofSeriesRequest WithTokenId(string value)
        {
            TokenId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ImportCofSeriesRequest WithTransactionLinkIdentifier(string value)
        {
            TransactionLinkIdentifier = value;
            return this;
        }
    }
}

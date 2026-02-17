/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OmnichannelPaymentSpecificInput
    {
        /// <summary>
        /// Merchants may optionally include a user identifier to indicate which person within their organization initiated this request, enabling detailed audit trails and transaction accountability.
        /// If not provided, the field defaults to the merchant ID.
        /// </summary>
        public string OperatorId { get; set; }
    }
}

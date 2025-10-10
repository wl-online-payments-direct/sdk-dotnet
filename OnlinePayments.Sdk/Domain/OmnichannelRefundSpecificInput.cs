/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OmnichannelRefundSpecificInput
    {
        /// <summary>
        /// While calling Direct, the merchant can indicate which human user of their enterprise requested the action for reporting and auditing purposes.
        /// Note that it is up to the merchant to make up a code to identify the employee, for instance, the user ID of the employee logged on to the cash register. When not used, the field defaults to the merchant ID.
        /// </summary>
        public string OperatorId { get; set; }
    }
}

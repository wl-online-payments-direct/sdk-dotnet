/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class OmnichannelRefundSpecificInput
    {
        /// <summary>
        /// While calling Direct, the merchant can, for the sake of reporting and auditing, indicate which human user of his enterprise requested the action.
        /// Note that it is up to the merchant to make up a code to identify the employee, for instance, the userid of the employee logged on to the cash register. When not used, the field defaults to the merchant id.
        /// </summary>
        public string OperatorId { get; set; }
    }
}

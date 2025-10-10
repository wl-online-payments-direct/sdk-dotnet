/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RevokeMandateRequest
    {
        /// <summary>
        /// The reason for revoking the mandate.
        /// Possible values are:
        /// <list type="bullet">
        ///   <item><description>receivedFinal</description></item>
        ///   <item><description>userAction</description></item>
        ///   <item><description>obsolescence</description></item>
        ///   <item><description>refused</description></item>
        ///   <item><description>revocationAskedByDebitor</description></item>
        ///   <item><description>revocationAskedByCreditor</description></item>
        ///   <item><description>deletionAskedByDebitor</description></item>
        ///   <item><description>deletionAskedByCreditor</description></item>
        /// </list>
        /// <p />
        /// Refer to the support page to determine if the property is applicable.
        /// </summary>
        public string RevocationReason { get; set; }
    }
}

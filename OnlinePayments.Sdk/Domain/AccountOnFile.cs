/*
 * This class was auto-generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class AccountOnFile
    {
        public IList<AccountOnFileAttribute> Attributes { get; set; } = null;

        /// <summary>
        /// Object containing information for the client on how best to display this field<para />
        /// </summary>
        public AccountOnFileDisplayHints DisplayHints { get; set; } = null;

        public int? Id { get; set; } = null;

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.<para />
        /// </summary>
        public int? PaymentProductId { get; set; } = null;
    }
}

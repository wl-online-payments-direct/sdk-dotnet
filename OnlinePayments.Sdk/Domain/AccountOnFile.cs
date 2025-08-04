/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class AccountOnFile
    {
        public IList<AccountOnFileAttribute> Attributes { get; set; }

        /// <summary>
        /// Object containing information for the client on how best to display this field
        /// </summary>
        public AccountOnFileDisplayHints DisplayHints { get; set; }

        /// <summary>
        /// ID of the token
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Payment product identifier - Please see Products documentation for a full overview of possible values.
        /// </summary>
        public int? PaymentProductId { get; set; }
    }
}

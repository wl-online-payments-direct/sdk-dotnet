/*
 * This file was automatically generated.
 */
using System;

namespace OnlinePayments.Sdk.Domain
{
    public class AccountOnFileAttribute
    {
        /// <summary>
        /// Name of the key or property
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Deprecated: This field is not used by any payment product
        /// The reason why the status is MUST_WRITE. Currently only &quot;IN_THE_PAST&quot; is possible as value (for expiry date), but this can be extended with new values in the future.
        /// </summary>
        [Obsolete("Deprecated")]
        public string MustWriteReason { get; set; }

        /// <summary>
        /// Possible values:
        /// <list type="bullet">
        ///   <item><description>READ_ONLY - attribute cannot be updated and should be presented in that way to the user</description></item>
        ///   <item><description>CAN_WRITE - attribute can be updated and should be presented as an editable field, for example an expiration date that will expire very soon</description></item>
        ///   <item><description>MUST_WRITE - attribute should be updated and must be presented as an editable field, for example an expiration date that has already expired
        /// Any updated values that are entered for CAN_WRITE or MUST_WRITE will be used to update the values stored in the token.</description></item>
        /// </list>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Value of the key or property
        /// </summary>
        public string Value { get; set; }
    }
}

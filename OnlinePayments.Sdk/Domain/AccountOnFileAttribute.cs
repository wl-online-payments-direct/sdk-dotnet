/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class AccountOnFileAttribute
    {
        /// <summary>
        /// Name of the key or property<para />
        /// </summary>
        public string Key { get; set; } = null;

        /// <summary>
        /// Deprecated: This field is not used by any payment product<para />
        /// The reason why the status is MUST_WRITE. Currently only "IN_THE_PAST" is possible as value (for expiry date), but this can be extended with new values in the future.<para />
        /// </summary>
        public string MustWriteReason { get; set; } = null;

        /// <summary>
        /// Possible values:<para />
        /// * READ_ONLY - attribute cannot be updated and should be presented in that way to the user<para />
        /// * CAN_WRITE - attribute can be updated and should be presented as an editable field, for example an expiration date that will expire very soon<para />
        /// * MUST_WRITE - attribute should be updated and must be presented as an editable field, for example an expiration date that has already expired<para />
        /// Any updated values that are entered for CAN_WRITE or MUST_WRITE will be used to update the values stored in the token.<para />
        /// </summary>
        public string Status { get; set; } = null;

        /// <summary>
        /// Value of the key or property<para />
        /// </summary>
        public string Value { get; set; } = null;
    }
}

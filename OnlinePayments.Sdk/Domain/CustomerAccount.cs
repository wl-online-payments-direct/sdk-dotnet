/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerAccount
    {
        /// <summary>
        /// Object containing data on the authentication used by the customer to access their account<para />
        /// </summary>
        public CustomerAccountAuthentication Authentication { get; set; } = null;

        /// <summary>
        /// The last date (YYYYMMDD) on which the customer made changes to their account with you. These are changes to billing & shipping address details, new payment account (tokens), or new users(s) added.<para />
        /// </summary>
        public string ChangeDate { get; set; } = null;

        /// <summary>
        /// * true = the customer made changes to their account during this checkout<para />
        /// * false = the customer did nnot change anything to their account during this checkout/n<para />
        /// <para />
        ///  The changes ment here are changes to billing & shipping address details, new payment account (tokens), or new users(s) added.<para />
        /// </summary>
        public bool? ChangedDuringCheckout { get; set; } = null;

        /// <summary>
        /// The date (YYYYMMDD) on which the customer created their account with you<para />
        /// </summary>
        public string CreateDate { get; set; } = null;

        /// <summary>
        /// Specifies if you have experienced suspicious activity on the account of the customer<para />
        /// <para />
        /// true = you have experienced suspicious activity (including previous fraud) on the customer account used for this transaction<para />
        /// <para />
        /// false = you have experienced no suspicious activity (including previous fraud) on the customer account used for this transaction<para />
        /// </summary>
        public bool? HadSuspiciousActivity { get; set; } = null;

        /// <summary>
        /// The last date (YYYYMMDD) on which the customer changed their password for the account used in this transaction<para />
        /// </summary>
        public string PasswordChangeDate { get; set; } = null;

        /// <summary>
        /// Indicates if the password of an account is changed during this checkout<para />
        /// <para />
        /// true = the customer made changes to their password of the account used during this checkout<para />
        /// <para />
        /// false = the customer did not change anything to their password of the account used during this checkout<para />
        /// </summary>
        public bool? PasswordChangedDuringCheckout { get; set; } = null;

        /// <summary>
        /// Object containing information on the payment account data on file (tokens)<para />
        /// </summary>
        public PaymentAccountOnFile PaymentAccountOnFile { get; set; } = null;

        /// <summary>
        /// Object containing data on the purchase history of the customer with you<para />
        /// </summary>
        public CustomerPaymentActivity PaymentActivity { get; set; } = null;
    }
}

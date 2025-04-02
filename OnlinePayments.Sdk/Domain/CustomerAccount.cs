/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CustomerAccount
    {
        /// <summary>
        /// Object containing data on the authentication used by the customer to access their account
        /// </summary>
        public CustomerAccountAuthentication Authentication { get; set; }

        /// <summary>
        /// The last date (YYYYMMDD) on which the customer made changes to their account with you. These are changes to billing &amp; shipping address details, new payment account (tokens), or new users(s) added.
        /// </summary>
        public string ChangeDate { get; set; }

        /// <summary>
        /// <list type="bullet">
        ///   <item><description>true = the customer made changes to their account during this checkout</description></item>
        ///   <item><description>false = the customer did nnot change anything to their account during this checkout/n</description></item>
        /// </list>
        /// <p />
        /// The changes ment here are changes to billing &amp; shipping address details, new payment account (tokens), or new users(s) added.
        /// </summary>
        public bool? ChangedDuringCheckout { get; set; }

        /// <summary>
        /// The date (YYYYMMDD) on which the customer created their account with you
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Specifies if you have experienced suspicious activity on the account of the customer
        /// <p />
        /// true = you have experienced suspicious activity (including previous fraud) on the customer account used for this transaction
        /// <p />
        /// false = you have experienced no suspicious activity (including previous fraud) on the customer account used for this transaction
        /// </summary>
        public bool? HadSuspiciousActivity { get; set; }

        /// <summary>
        /// The last date (YYYYMMDD) on which the customer changed their password for the account used in this transaction
        /// </summary>
        public string PasswordChangeDate { get; set; }

        /// <summary>
        /// Indicates if the password of an account is changed during this checkout
        /// <p />
        /// true = the customer made changes to their password of the account used during this checkout
        /// <p />
        /// false = the customer did not change anything to their password of the account used during this checkout
        /// </summary>
        public bool? PasswordChangedDuringCheckout { get; set; }

        /// <summary>
        /// Object containing information on the payment account data on file (tokens)
        /// </summary>
        public PaymentAccountOnFile PaymentAccountOnFile { get; set; }

        /// <summary>
        /// Object containing data on the purchase history of the customer with you
        /// </summary>
        public CustomerPaymentActivity PaymentActivity { get; set; }
    }
}

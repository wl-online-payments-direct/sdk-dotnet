/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference/index.html
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CustomerAccount
    {
        public CustomerAccountAuthentication Authentication { get; set; } = null;

        public string ChangeDate { get; set; } = null;

        public bool? ChangedDuringCheckout { get; set; } = null;

        public string CreateDate { get; set; } = null;

        public bool? HadSuspiciousActivity { get; set; } = null;

        public string PasswordChangeDate { get; set; } = null;

        public bool? PasswordChangedDuringCheckout { get; set; } = null;

        public PaymentAccountOnFile PaymentAccountOnFile { get; set; } = null;

        public CustomerPaymentActivity PaymentActivity { get; set; } = null;
    }
}

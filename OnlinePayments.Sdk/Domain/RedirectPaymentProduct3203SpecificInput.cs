/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct3203SpecificInput
    {
        /// <summary>
        /// Determines the type of the checkout that will be used for PostFinancePay. Allowed values:
        /// <list type="bullet">
        ///   <item><description>default - The user will be redirected to the PostFinancePay application to complete the payment.</description></item>
        ///   <item><description>expressCheckout -  In order to accelerate the payment process, the shipping and billing addresses are requested
        /// from the payer's PostFinancePay account. These will be returned in the API response in
        /// paymentProduct3203SpecificOutput. Note that the payer must accept to provide his
        /// billing and shipping address during checkout in the PostFinancePay application.
        /// If not, the payment will be declined.</description></item>
        /// </list>
        /// </summary>
        public string CheckoutType { get; set; }
    }
}

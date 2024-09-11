/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class RedirectPaymentProduct3203SpecificInput
    {
        /// <summary>
        /// Determines the type of the checkout that will be used for PostFinancePay. Allowed values:<para />
        ///   * default - The user will be redirected to the PostFinancePay application to complete the payment.<para />
        ///   * expressCheckout -  In order to accelerate the payment process, the shipping and billing addresses are requested <para />
        ///                        from the payer's PostFinancePay account. These will be returned in the API response in <para />
        ///                        paymentProduct3203SpecificOutput. Note that the payer must accept to provide his <para />
        ///                        billing and shipping address during checkout in the PostFinancePay application. <para />
        ///                        If not, the payment will be declined.<para />
        /// </summary>
        public string CheckoutType { get; set; } = null;
    }
}

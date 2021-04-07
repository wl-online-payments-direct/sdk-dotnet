/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class CardPaymentMethodSpecificInputForHostedCheckout
    {
        /// <summary>
        /// * true - Hosted Checkout will allow to show cards grouped as one payment method<para />
        /// * false - Default - Hosted Checkout will show cards as separate payment methods<para />
        /// </summary>
        public bool? GroupCards { get; set; } = null;
    }
}

/*
 * This class was auto-generated from the API references found at
 * https://support.direct.ingenico.com/documentation/api/reference
 */
namespace Ingenico.Direct.Sdk.Domain
{
    public class RefundEWalletMethodSpecificOutput
    {
        public RefundPaymentProduct840SpecificOutput PaymentProduct840SpecificOutput { get; set; } = null;

        public long? TotalAmountPaid { get; set; } = null;

        public long? TotalAmountRefunded { get; set; } = null;
    }
}

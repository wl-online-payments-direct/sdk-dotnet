/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFieldValidators
    {
        public EmptyValidator EmailAddress { get; set; } = null;

        public EmptyValidator ExpirationDate { get; set; } = null;

        public FixedListValidator FixedList { get; set; } = null;

        public EmptyValidator Iban { get; set; } = null;

        public LengthValidator Length { get; set; } = null;

        public EmptyValidator Luhn { get; set; } = null;

        public RangeValidator Range { get; set; } = null;

        public RegularExpressionValidator RegularExpression { get; set; } = null;

        public EmptyValidator TermsAndConditions { get; set; } = null;
    }
}

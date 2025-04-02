/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class PaymentProductFieldValidators
    {
        public EmptyValidator EmailAddress { get; set; }

        public EmptyValidator ExpirationDate { get; set; }

        public FixedListValidator FixedList { get; set; }

        public EmptyValidator Iban { get; set; }

        public LengthValidator Length { get; set; }

        public EmptyValidator Luhn { get; set; }

        public RangeValidator Range { get; set; }

        public RegularExpressionValidator RegularExpression { get; set; }

        public EmptyValidator TermsAndConditions { get; set; }
    }
}

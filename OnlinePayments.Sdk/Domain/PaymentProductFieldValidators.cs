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

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithEmailAddress(EmptyValidator value)
        {
            EmailAddress = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithExpirationDate(EmptyValidator value)
        {
            ExpirationDate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithFixedList(FixedListValidator value)
        {
            FixedList = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithIban(EmptyValidator value)
        {
            Iban = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithLength(LengthValidator value)
        {
            Length = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithLuhn(EmptyValidator value)
        {
            Luhn = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithRange(RangeValidator value)
        {
            Range = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithRegularExpression(RegularExpressionValidator value)
        {
            RegularExpression = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public PaymentProductFieldValidators WithTermsAndConditions(EmptyValidator value)
        {
            TermsAndConditions = value;
            return this;
        }
    }
}

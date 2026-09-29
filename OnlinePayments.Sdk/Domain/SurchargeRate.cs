/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SurchargeRate
    {
        /// <summary>
        /// A percentage rate defined on a merchant's configuration used in the calculation of a surcharge amount.
        /// </summary>
        public decimal? AdValoremRate { get; set; }

        /// <summary>
        /// A specific, fixed rate in cents defined on a merchant's configuration that is used in the calculation of a surcharge amount.
        /// </summary>
        public int? SpecificRate { get; set; }

        /// <summary>
        /// The name of the applicable surcharge rates for the relevant payment product
        /// </summary>
        public string SurchargeProductTypeId { get; set; }

        /// <summary>
        /// A specific version identifier of the surcharge rates as applied for this request
        /// </summary>
        public string SurchargeProductTypeVersion { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SurchargeRate WithAdValoremRate(decimal? value)
        {
            AdValoremRate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SurchargeRate WithSpecificRate(int? value)
        {
            SpecificRate = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SurchargeRate WithSurchargeProductTypeId(string value)
        {
            SurchargeProductTypeId = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public SurchargeRate WithSurchargeProductTypeVersion(string value)
        {
            SurchargeProductTypeVersion = value;
            return this;
        }
    }
}

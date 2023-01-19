/*
 * This class was auto-generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class SurchargeRate
    {
        /// <summary>
        /// A percentage rate defined on a merchant's configuration used in the calculation of a surcharge amount.<para />
        /// </summary>
        public decimal? AdValoremRate { get; set; } = null;

        /// <summary>
        /// A specific, fixed rate in cents defined on a merchant's configuration that is used in the calculation of a surcharge amount.<para />
        /// </summary>
        public int? SpecificRate { get; set; } = null;

        /// <summary>
        /// The name of the applicable surcharge rates for the relevant payment product<para />
        /// </summary>
        public string SurchargeProductTypeId { get; set; } = null;

        /// <summary>
        /// A specific version identifier of the surcharge rates as applied for this request<para />
        /// </summary>
        public string SurchargeProductTypeVersion { get; set; } = null;
    }
}

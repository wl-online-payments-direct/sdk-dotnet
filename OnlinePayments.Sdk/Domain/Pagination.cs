/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class Pagination
    {
        /// <summary>
        /// The page number to retrieve (1-based). Default is 1.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Number of results per page. Default is 50, maximum is 1000.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Pagination WithPage(int? value)
        {
            Page = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public Pagination WithPageSize(int? value)
        {
            PageSize = value;
            return this;
        }
    }
}

/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class CursorPaginationInfo
    {
        /// <summary>
        /// Indicates whether more results are available
        /// </summary>
        public bool? HasMore { get; set; }

        /// <summary>
        /// Opaque cursor for retrieving the next page. Null if no more results available.
        /// </summary>
        public string NextCursor { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CursorPaginationInfo WithHasMore(bool? value)
        {
            HasMore = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public CursorPaginationInfo WithNextCursor(string value)
        {
            NextCursor = value;
            return this;
        }
    }
}

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
    }
}

using System.Collections.Generic;

namespace OnlinePayments.Sdk.Communication
{
    public interface IMetadataProvider
    {
        /// <summary>
        /// Gets the server related headers containing the metadata to be associated with the request (if any).
        /// This will always contain at least an automatically generated header <c>X-GCS-ServerMetaInfo</c>.
        /// </summary>
        IEnumerable<IRequestHeader> ServerMetadataHeaders { get; }
    }
}

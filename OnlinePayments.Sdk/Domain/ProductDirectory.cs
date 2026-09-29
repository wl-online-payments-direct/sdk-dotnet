/*
 * This file was automatically generated.
 */
using System.Collections.Generic;

namespace OnlinePayments.Sdk.Domain
{
    public class ProductDirectory
    {
        /// <summary>
        /// List of entries in the directory
        /// </summary>
        public IList<DirectoryEntry> Entries { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ProductDirectory WithEntries(IList<DirectoryEntry> value)
        {
            Entries = value;
            return this;
        }
    }
}

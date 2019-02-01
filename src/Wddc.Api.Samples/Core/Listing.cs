using System.Collections.Generic;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// List of entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Listing<T>
    {
        /// <summary>
        /// Page number
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Total number of records
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// List of results
        /// </summary>
        public IEnumerable<T> Results { get; set; }
    }
}

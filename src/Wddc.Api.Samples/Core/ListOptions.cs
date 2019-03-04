using Newtonsoft.Json;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Request options
    /// </summary>
    public class ListOptions
    {
        /// <summary>
        /// Starting page
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Size of page
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Sort by field_dir
        /// </summary>
        public string Sort { get; set; }
    }
}
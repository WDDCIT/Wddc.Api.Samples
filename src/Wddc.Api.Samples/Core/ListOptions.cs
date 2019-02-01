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
        [JsonProperty("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Size of page
        /// </summary>
        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }
    }
}
using System.Collections.Generic;

namespace Wddc.Api.Samples.Core
{
    public class BulkAddToCartResponse
    {
        public string Error { get; set; }
        public int ItemAddedCount { get; set; }
        public ICollection<DroppedProducts> ItemsDropped { get; set; }
    }
}

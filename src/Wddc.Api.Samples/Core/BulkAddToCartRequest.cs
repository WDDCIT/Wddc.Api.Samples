using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wddc.Api.Samples.Core
{
    public class BulkAddToCartRequest
    {
        /// <summary>
        /// Customer identitfier
        /// </summary>
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Purchase order
        /// </summary>
        [JsonProperty("purchaseOrder")]
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// Add to cart requests
        /// </summary>
        [JsonProperty("orderItems")]
        public IEnumerable<AddToCartRequest> OrderItems { get; set; }
    }
}

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
        public string CustomerId { get; set; }

        /// <summary>
        /// Add to cart requests
        /// </summary>
        public IEnumerable<AddToCartRequest> AddToCartRequests { get; set; }
    }
}

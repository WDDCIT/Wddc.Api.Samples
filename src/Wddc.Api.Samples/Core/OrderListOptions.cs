using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wddc.Api.Samples.Core
{
    public class OrderListOptions : ListOptions
    {
        /// <summary>
        /// Filter by customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Filter by purchase order number
        /// </summary>
        public string PurchaseOrderNumber { get; set; }
    }
}

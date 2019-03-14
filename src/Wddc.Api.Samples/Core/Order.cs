using System;
using System.Collections.Generic;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Wddc Order
    /// </summary>
    public class Order : WddcApiEntity
    {
        /// <summary>
        /// Type of order, whether ordered from the web, special order, client vantage order etc
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// Customer identifier
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Purchase order
        /// </summary>
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// Order total
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// Order created date
        /// </summary>
        public DateTime CreatedUtc { get; set; }
        /// <summary>
        /// Gets or sets the order items
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
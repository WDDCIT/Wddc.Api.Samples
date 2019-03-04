using System;
using System.Collections.Generic;

namespace Wddc.Api.Samples.Core
{
    public class OrderStatusResult
    {
        /// <summary>
        /// Type of order, whether ordered from the web, special order, client vantage order etc
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// Purchase order
        /// </summary>
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// Original order note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Customer identifier
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Order created date
        /// </summary>
        public DateTime CreatedUtc { get; set; }

        /// <summary>
        /// Order items
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Any errors
        /// </summary>
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public OrderStatus OrderStatus { get; set; }
    }
}

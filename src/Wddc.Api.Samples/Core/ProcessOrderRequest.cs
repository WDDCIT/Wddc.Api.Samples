using System;
using System.Collections.Generic;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Request to process a new WDDC order
    /// </summary>
    public class ProcessOrderRequest : WddcApiEntity
    {
        public ProcessOrderRequest()
        {
            OrderItems = new List<OrderItem>();
        }

        /// <summary>
        /// Put your unique identifier for your order here, so you can keep track of it for later
        /// </summary>
        public int? OriginalOrderId { get; set; }

        /// <summary>
        /// WDDC customer identifier
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Total of the order
        /// </summary>
        public decimal? OrderTotal { get; set; }

        /// <summary>
        /// Purchase order
        /// </summary>
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// Shipping address
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Billing address
        /// </summary>
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Shipping method
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// Gets or sets the order items
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Gets or sets the order date
        /// </summary>
        public DateTime? OrderDateUtc { get; set; }

        /// <summary>
        /// Order Type
        /// </summary>
        /// <remarks>Special Orders Only</remarks>
        public string OrderType { get; set; }

        /// <summary>
        /// Sales Batch
        /// </summary>
        /// <remarks>Special Orders Only</remarks>
        public string SalesBatch { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        /// <remarks>Special Orders Only</remarks>
        public string Note { get; set; }

        /// <summary>
        /// Gst
        /// </summary>
        /// <remarks>Special Orders Only</remarks>
        public decimal? Gst { get; set; }

        /// <summary>
        /// Promo
        /// </summary>
        /// <remarks>Special Orders Only</remarks>
        public decimal? Promo { get; set; }

        /// <summary>
        /// Marks as special order
        /// </summary>
        public bool? IsSpecialOrder { get; set; }
    }
}

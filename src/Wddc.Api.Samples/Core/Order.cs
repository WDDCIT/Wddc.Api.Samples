using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wddc.Api.Samples.Core
{

    /// <summary>
    /// WDDC web order
    /// </summary>
    public class Order : WddcApiEntity
    {
        private ICollection<OrderItem> _orderItems;
        private ICollection<Shipment> _orderShipments;
        private ICollection<OrderNote> _orderNotes;

        /// <summary>
        /// Id of customer
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the billing address of the order
        /// </summary>
        public int? BillingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the shipping address of the order
        /// </summary>
        public int? ShippingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the client id that created the order
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the id of the store the order belongs tto
        /// </summary>
        public int? OriginalOrderId { get; set; }

        /// <summary>
        /// Gets or sets the datetime the order was created
        /// </summary>
        public DateTime CreatedUtc { get; set; }

        /// <summary>
        /// Gets or sets the purchase order number of the order
        /// </summary>
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// Gets or sets the datetime when the original order was created
        /// </summary>
        public DateTime? OrderDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the status of the order
        /// </summary>
        public int OrderStatusId { get; set; }

        /// <summary>
        /// Gets or sets the log level
        /// </summary>
        public OrderStatus OrderStatus
        {
            get
            {
                return (OrderStatus)this.OrderStatusId;
            }
            set
            {
                this.OrderStatusId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the total of the order
        /// </summary>
        public decimal? OrderTotal { get; set; }

        /// <summary>
        /// Gets or sets the shipping method
        /// </summary>
        public string ShippingMethod { get; set; }

        /// <summary>
        /// Gets or sets the shipping estimate excluding taxes
        /// </summary>
        public decimal ShippingEstimateExclTax { get; set; }

        /// <summary>
        /// Processed date
        /// </summary>
        public DateTime? ProcessedUtc { get; set; }

        /// <summary>
        /// Sales batch
        /// </summary>
        public string SalesBatch { get; set; }

        /// <summary>
        /// Order type
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// User that created the order
        /// </summary>
        public int CreatedByUser { get; set; }

        /// <summary>
        /// Gets or sets the customer billing address
        /// </summary>
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the customer shipping address
        /// </summary>
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets the order items
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems
        {
            get { return _orderItems ?? (_orderItems = new List<OrderItem>()); }
            set { _orderItems = value; }
        }

        /// <summary>
        /// Gets or sets the order shipments
        /// </summary>
        public virtual ICollection<Shipment> OrderShipments
        {
            get { return _orderShipments ?? (_orderShipments = new List<Shipment>()); }
            set { _orderShipments = value; }
        }

        /// <summary>
        /// Gets or sets the order notes
        /// </summary>
        public virtual ICollection<OrderNote> OrderNotes
        {
            get { return _orderNotes ?? (_orderNotes = new List<OrderNote>()); }
            set { _orderNotes = value; }
        }
    }
}

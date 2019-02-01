using System.Collections.Generic;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Shipment
    /// </summary>
    public class Shipment : WddcApiEntity
    {
        private ICollection<ShipmentItem> _shipmentDetails;

        /// <summary>
        /// Order Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Tracking number
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Gets or sets ShipmentDetails
        /// </summary>
        public virtual ICollection<ShipmentItem> ShipmentItems
        {
            get { return _shipmentDetails ?? (_shipmentDetails = new List<ShipmentItem>()); }
            set { _shipmentDetails = value; }
        }
    }
}
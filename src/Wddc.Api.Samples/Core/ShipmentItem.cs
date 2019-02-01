namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Shipment detail
    /// </summary>
    public class ShipmentItem : WddcApiEntity
    {
        /// <summary>
        /// ShipmentId
        /// </summary>
        public int ShipmentId { get; set; }

        /// <summary>
        /// Product Sku
        /// </summary>
        public string ProductSku { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Shipment
        /// </summary>
        public virtual Shipment Shipment { get; set; }
    }
}
namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Order item
    /// </summary>
    public class OrderItem : WddcApiEntity
    {
        /// <summary>
        /// Order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Product sku
        /// </summary>
        public string ProductSku { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// original order item id
        /// </summary>
        public int OriginalOrderItemId { get; set; }

        /// <summary>
        /// original product id
        /// </summary>
        public int OriginalProductId { get; set; }

        /// <summary>
        /// Display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Pricing level
        /// </summary>
        public string PricingLevel { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
    }
}

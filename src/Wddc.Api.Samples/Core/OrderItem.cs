namespace Wddc.Api.Samples.Core
{
    public class OrderItem : WddcApiEntity
    {
        /// <summary>
        /// Quantity ordered
        /// </summary>
        public decimal QuantityOrdered { get; set; }

        /// <summary>
        /// Quantity invoiced
        /// </summary>
        public decimal QuantityInvoiced { get; set; }

        /// <summary>
        /// Quantity put on back order
        /// </summary>
        public decimal QuantityBackOrdered { get; set; }

        /// <summary>
        /// Product sku
        /// </summary>
        public string ProductSku { get; set; }

        /// <summary>
        /// Wddc product
        /// </summary>
        public Product Product { get; set; }
    }
}
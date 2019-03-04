using System;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Shopping cart item
    /// </summary>
    public class ShoppingCartItem
    {
        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product sku / item number
        /// </summary>
        public string ProductSku { get; set; }

        /// <summary>
        /// Updated/Inserted/Deleted status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Last time updated
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Origin (CV = 1000)
        /// </summary>
        public int Origin { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        public Product Product { get; set; }
    }
}
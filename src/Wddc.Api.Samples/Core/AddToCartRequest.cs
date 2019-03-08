namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Update shopping cart
    /// </summary>
    public class AddToCartRequest
    {
        /// <summary>
        /// Product sku to add to cart
        /// </summary>
        public string ProductSku { get; set; }

        /// <summary>
        /// Quantity of product to purchase
        /// </summary>
        public int Quantity { get; set; }
    }
}

namespace Wddc.Api.Samples.Core
{
    public class AddToCartResult
    {
        public string ProductSku { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public ShoppingCart UpdatedShoppingCart { get; set; }
    }
}

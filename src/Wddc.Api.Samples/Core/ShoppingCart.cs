using System.Collections.Generic;
using Wddc.Api.Samples.Core;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Shopping cart
    /// </summary>
    public class ShoppingCart : WddcApiEntity
    {
        /// <summary>
        /// Customer ID / member number
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Shopping cart items
        /// </summary>
        public IEnumerable<ShoppingCartItem> Items { get; set; }
    }
}

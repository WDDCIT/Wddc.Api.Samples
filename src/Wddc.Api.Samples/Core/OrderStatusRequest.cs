namespace Wddc.Api.Samples.Core
{
    public class OrderStatusRequest
    {
        /// <summary>
        /// Search by order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Order entity
        /// </summary>
        public string OrderType { get; set; }
    }
}

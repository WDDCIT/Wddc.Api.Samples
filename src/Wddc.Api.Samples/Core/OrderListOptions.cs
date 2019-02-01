using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Wddc.Api.Samples.Core
{
    public class OrderListOptions : ListOptions
    {
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("originalOrderId")]
        public int? OriginalOrderId { get; set; }

        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        [JsonProperty("billingEmail")]
        public string BillingEmail { get; set; }

        [JsonProperty("startDateUtc")]
        public DateTime? StartDateUtc { get; set; }

        [JsonProperty("endDateUtc")]
        public DateTime? EndDateUtc { get; set; }

        [JsonProperty("productSku")]
        public string Sku { get; set; }

        [JsonProperty("orderStatuses")]
        public ICollection<OrderStatus> OrderStatuses { get; set; }

        public OrderListOptions()
        {
            OrderStatuses = new List<OrderStatus>();
        }
    }
}

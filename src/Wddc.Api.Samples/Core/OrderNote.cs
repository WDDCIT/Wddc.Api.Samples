using System;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Order note
    /// </summary>
    public class OrderNote : WddcApiEntity
    {
        /// <summary>
        /// Order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Display to customer
        /// </summary>
        public bool DisplayToCustomer { get; set; }

        /// <summary>
        /// Created UTC
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }
}
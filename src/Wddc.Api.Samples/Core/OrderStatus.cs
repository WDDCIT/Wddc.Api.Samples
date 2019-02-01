namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Status for web orders
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Has been sent to WDDC, and is waiting to be processed
        /// </summary>
        NotProcessed = 0,

        /// <summary>
        /// Has been sent to ASC, and is ready to be picked
        /// </summary>
        Processed = 1,

        /// <summary>
        /// Has been partially shipped from WDDC
        /// </summary>
        PartiallyShipped = 10,

        /// <summary>
        /// Has been shipped from WDDC
        /// </summary>
        Shipped = 15,

        /// <summary>
        /// Has been received by the clinic
        /// </summary>
        Completed = 20,

        /// <summary>
        /// No shipping required
        /// </summary>
        NoShippingRequired = 25,
    }
}
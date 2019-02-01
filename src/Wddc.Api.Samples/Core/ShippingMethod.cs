namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Shipping method to use
    /// </summary>
    public enum ShippingMethod
    {
        /// <summary>
        /// Shipping direct through purolator to customers address, with a special box with customers information on it
        /// </summary>
        BoxAndShipToHome,

        /// <summary>
        /// Shipping direct to clinic, with a special box with customers information on it
        /// </summary>
        BoxAndShipToClinic,

        /// <summary>
        /// Regular WDDC shipping
        /// </summary>
        RegularShipping,

        /// <summary>
        /// WDDC will not ship this order, used to track orders
        /// </summary>
        NoShippingRequired
    }
}

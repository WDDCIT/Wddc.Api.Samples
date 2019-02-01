namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// nopCommerce billing address
    /// </summary>
    public class Address : WddcApiEntity
    {
        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Address1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Zip postal code
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// CountryTwoLetterIsoCode
        /// </summary>
        public string CountryTwoLetterIsoCode { get; set; }

        /// <summary>
        /// StateProvinceAbbreviation
        /// </summary>
        public string StateProvinceAbbreviation { get; set; }

        /// <summary>
        /// nopCommerce Client Vantage customer id
        /// </summary>
        public int OriginalAddressId { get; set; }
    }
}

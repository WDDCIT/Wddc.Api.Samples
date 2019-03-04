using System;
using System.Text.RegularExpressions;

namespace Wddc.Api.Samples.Core
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product : WddcApiEntity
    {
        /// <summary>
        /// Product item id/sku
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Item type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Alternate product
        /// </summary>
        public string AlternateProduct { get; set; }

        /// <summary>
        /// Price group
        /// </summary>
        public string PriceGroup { get; set; }

        /// <summary>
        /// Short name
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Generic description
        /// </summary>
        public string GenericDescription { get; set; }

        /// <summary>
        /// Unit of measure schedule
        /// </summary>
        public string UofMSchedule { get; set; }

        /// <summary>
        /// Price level
        /// </summary>
        public string PriceLevel { get; set; }

        /// <summary>
        /// Location code
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// Modified date
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        public decimal Weight { get; set; }

        #region Categorization
        /*
         * Our categorization works as follows
         *  - every product has a superclass, class, subclass which are basically categories
         *  - class is parent of subclass, and superclass is parent of class
         */

        /// <summary>
        /// Sub class id
        /// </summary>
        public int SubClassId { get; set; }

        /// <summary>
        /// Sub class description
        /// </summary>
        public string SubClassDescription { get; set; }

        /// <summary>
        /// Class id
        /// </summary>
        public int ClassID { get; set; }

        /// <summary>
        /// Class description
        /// </summary>
        public string ClassDescription { get; set; }

        /// <summary>
        /// Super class id
        /// </summary>
        public int SuperClassID { get; set; }

        /// <summary>
        /// Super class description
        /// </summary>
        public string SuperClassDescription { get; set; }

        #endregion

        /// <summary>
        /// Full description
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Price if case is bought
        /// </summary>
        public decimal CasePrice { get; set; }

        /// <summary>
        /// Quantity required to buy case
        /// </summary>
        public decimal CaseQuantity { get; set; }

        ///// <summary>
        ///// Inactive
        ///// </summary>
        public bool Inactive { get; set; }

        ///// <summary>
        ///// Allow backorders
        ///// </summary>
        public bool AllowBackorders { get; set; }

        /// <summary>
        /// Is product discontinued
        /// </summary>
        public bool IsDiscontinued { get; set; }

        /// <summary>
        /// Products needs to be in freezer
        /// </summary>
        public bool NeedsFreezer { get; set; }

        /// <summary>
        /// Product is considered a dangerous good
        /// </summary>
        public bool IsDangerousGoods { get; set; }

        /// <summary>
        /// Product is temporarily unavailable
        /// </summary>
        public bool IsTemporarilyUnavailable { get; set; }

        /// <summary>
        /// Tranisiont product, usually means will be 
        /// discontinued/unavailable after stock runs out
        /// </summary>
        public bool IsTransitionProduct { get; set; }

        /// <summary>
        /// Price is only available on request
        /// </summary>
        public bool IsPriceOnRequest { get; set; }

        /// <summary>
        /// Product requires a special order and will usually take longer
        /// to ship
        /// </summary>
        public bool IsSpecialOrder { get; set; }

        /// <summary>
        /// Whether or not the product is returnable
        /// </summary>
        public bool IsReturnable { get; set; }
    }
}
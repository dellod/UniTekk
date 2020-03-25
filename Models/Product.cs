using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models
{
    public abstract class Product
    {
        #region Properties
        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Unique ID of the product
        /// </summary>
        public int ProductID
        {
            get; set;
        }

        public Brand ProductBrand
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (nescessary for deserialization).
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="productid">ID of product.</param>
        /// <param name="productBrand">Brand of product.</param>
        public Product(string name, int productid, Brand productBrand)
        {
            Name = name;
            ProductID = productid;
            ProductBrand = productBrand;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance">Instance of product that is being copied.</param>
        public Product(Product instance) : this(instance.Name, instance.ProductID, instance.ProductBrand)
        {

        }
        #endregion
    }
}
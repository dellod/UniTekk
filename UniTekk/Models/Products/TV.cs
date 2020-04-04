using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models.Products
{
    public class TV : Product
    {
        #region Properties
        /// <summary>
        /// Horizontal pixel resolution.
        /// </summary>
        public int HorizontalPixels
        {
            get; set;
        }

        /// <summary>
        /// Vertical pixel resolution.
        /// </summary>
        public int VerticalPixels
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (nescessary for deserialization).
        /// </summary>
        public TV()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="tvName">Name of TV.</param>
        /// <param name="tvId">Product ID of TV.</param>
        /// <param name="brand">Brand of TV.</param>
        /// <param name="price">Price of TV.</param>
        /// <param name="availability">Stock of specific TV.</param>
        /// <param name="horizontalPixels">Horizontal resolution.</param>
        /// <param name="verticalPixels">Vertical resolution.</param>
        public TV(string tvName, int tvId, Brand brand, double price, int availability, int horizontalPixels, int verticalPixels) : base(tvName, tvId, brand, price, availability)
        {
            HorizontalPixels = horizontalPixels;
            VerticalPixels = verticalPixels;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance">Instance of TV that is being copied.</param>
        public TV(TV instance) : this(instance.Name, instance.ProductID, instance.ProductBrand, instance.Price, instance.Availability, instance.HorizontalPixels, instance.VerticalPixels)
        {

        }
        #endregion
    }
}
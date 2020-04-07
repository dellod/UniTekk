using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models.Products
{
    public class TV 
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
        /// <param Name="tvName">Name of TV.</param>
        /// <param Name="tvId">Product ID of TV.</param>
        /// <param Name="brand">Brand of TV.</param>
        /// <param Name="price">Price of TV.</param>
        /// <param Name="availability">Stock of specific TV.</param>
        /// <param Name="horizontalPixels">Horizontal resolution.</param>
        /// <param Name="verticalPixels">Vertical resolution.</param>
        public TV(int horizontalPixels, int verticalPixels)
        { 
            HorizontalPixels = horizontalPixels;
            VerticalPixels = verticalPixels;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param Name="instance">Instance of TV that is being copied.</param>
        public TV(TV instance) : this(instance.HorizontalPixels, instance.VerticalPixels)
        {

        }
        #endregion

    }
}
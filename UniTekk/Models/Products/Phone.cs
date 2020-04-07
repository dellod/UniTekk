using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models.Products
{
    public class Phone
    {
        #region Properties
        /// <summary>
        /// Thickness of phone.
        /// </summary>
        public double Thickness
        {
            get; set;
        }

        /// <summary>
        /// Width of phone.
        /// </summary>
        public double Width
        {
            get; set;
        }

        /// <summary>
        /// Height of phone.
        /// </summary>
        public double Height
        {
            get; set;
        }
        #endregion


        #region Constructors
        /// <summary>
        /// Default constructor (necessary for deserialization).
        /// </summary>
        public Phone()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param Name="phoneName">Name of phone.</param>
        /// <param Name="productId">Product ID of phone.</param>
        /// <param Name="brand">Brand of phone.</param>
        /// <param Name="price">Price of phone.</param>
        /// <param Name="availability">Stock of specific phone.</param>
        /// <param Name="thick">Thickness of phone.</param>
        /// <param Name="width">Width of phone.</param>
        /// <param Name="height">Height of phone.</param>
        public Phone(double thick, double width, double height)
        {
            Thickness = thick;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param Name="instance">Instance of phone that is being copied.</param>
        public Phone(Phone instance) : this( instance.Thickness, instance.Width, instance.Height)
        {

        }
        #endregion
    }
}
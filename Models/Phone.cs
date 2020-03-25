using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models
{
    public class Phone : Product
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
        /// <param name="phoneName">Name of phone.</param>
        /// <param name="productId">Product ID of phone.</param>
        /// <param name="brand">Brand of phone.</param>
        /// <param name="price">Price of phone.</param>
        /// <param name="availability">Stock of specific phone.</param>
        /// <param name="thick">Thickness of phone.</param>
        /// <param name="width">Width of phone.</param>
        /// <param name="height">Height of phone.</param>
        public Phone(string phoneName, int productId, Brand brand, double price, int availability, double thick, double width, double height) : base(phoneName, productId, brand, price, availability)
        {
            Thickness = thick;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance">Instance of phone that is being copied.</param>
        public Phone(Phone instance) : this(instance.Name, instance.ProductID, instance.ProductBrand, instance.Price, instance.Availability, instance.Thickness, instance.Width, instance.Height)
        {

        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models.Products
{
    public class Laptop : Product
    {
        #region Properties
        /// <summary>
        /// RAM of laptop.
        /// </summary>
        public int RAM
        {
            get; set;
        }

        /// <summary>
        /// Clock Frequency of laptop.
        /// </summary>
        public int ClockFrequency
        {
            get; set;
        }

        /// <summary>
        /// Thickness of laptop.
        /// </summary>
        public double Thickness
        {
            get; set;
        }

        /// <summary>
        /// Width of laptop.
        /// </summary>
        public double Width
        {
            get; set;
        }

        /// <summary>
        /// Height of laptop.
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
        public Laptop()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="laptopName">Name of laptop.</param>
        /// <param name="laptopId">Product ID of laptop.</param>
        /// <param name="brand">Brand of laptop.</param>
        /// <param name="price">Price of laptop.</param>
        /// <param name="availability">Stock of specific laptop.</param>
        /// <param name="ram">RAM of laptop.</param>
        /// <param name="clock">Clock frequency of laptop.</param>
        /// <param name="thick">Thickness of laptop.</param>
        /// <param name="width">Width of laptop.</param>
        /// <param name="height">Height of laptop.</param>
        public Laptop(string laptopName, int laptopId, Brand brand, double price, int availability, int ram, int clock, double thick, double width, double height) : base(laptopName, laptopId, brand, price, availability)
        {
            RAM = ram;
            ClockFrequency = clock;
            Thickness = thick;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance">Instance of laptop that is being copied.</param>
        public Laptop(Laptop instance) : this(instance.Name, instance.ProductID, instance.ProductBrand, instance.Price, instance.Availability, instance.RAM, instance.ClockFrequency, instance.Thickness, instance.Width, instance.Height)
        {

        }
        #endregion

    }
}
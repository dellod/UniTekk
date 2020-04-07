using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models.Products
{
    public class Laptop

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
        /// <param Name="laptopName">Name of laptop.</param>
        /// <param Name="laptopId">Product ID of laptop.</param>
        /// <param Name="brand">Brand of laptop.</param>
        /// <param Name="price">Price of laptop.</param>
        /// <param Name="availability">Stock of specific laptop.</param>
        /// <param Name="ram">RAM of laptop.</param>
        /// <param Name="clock">Clock frequency of laptop.</param>
        /// <param Name="thick">Thickness of laptop.</param>
        /// <param Name="width">Width of laptop.</param>
        /// <param Name="height">Height of laptop.</param>
        public Laptop( int ram, int clock, double thick, double width, double height)
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
        /// <param Name="instance">Instance of laptop that is being copied.</param>
        public Laptop(Laptop instance) : this( instance.RAM, instance.ClockFrequency, instance.Thickness, instance.Width, instance.Height)
        {

        }
        #endregion

    }
}
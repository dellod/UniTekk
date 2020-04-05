﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniTekk.Models.Products;

namespace UniTekk.Models
{
    public class Seller
    {
        #region Properties
        /// <summary>
        /// Name of the seller.
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// TODO: I don't know what this is.
        /// </summary>
        public string Link
        {
            get; set;
        }

        /// <summary>
        /// Unique ID of the seller.
        /// </summary>
        public int SellerId
        {
            get; set;
        }

        /// <summary>
        /// The products that the seller owns.
        /// </summary>
        public List<Product> Products
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (necessary for deserialization).
        /// </summary>
        public Seller()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="name">Name of seller.</param>
        /// <param name="link">TODO</param>
        /// <param name="sellerId">Unique of ID of seller.</param>
        /// <param name="products">Products that the seller owns.</param>
        public Seller(string name, string link, int sellerId, List<Product> products)
        {
            Name = name;
            Link = link;
            SellerId = sellerId;
            Products = products;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance">Instance of seller that is being copied.</param>
        public Seller(Seller instance) : this(instance.Name, instance.Link, instance.SellerId, instance.Products)
        {

        }
        #endregion


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models.Products
{
    public class Seller
    {
        #region Properties
        /// <summary>
        /// Name of the brand.
        /// </summary>
        public string name
        {
            get; set;
        }
        


        public string link
        {
            get; set;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor (nescessary for deserialization).
        /// </summary>
        public Seller()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param Name="name">Name of brand.</param>
        /// <param Name="brandid">ID of brand.</param>
        public Seller(string name, string lin)
        {
            this.name = name;
            this.link = lin;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param Name="instance">Instance of brand that is being copied.</param>
        public Seller(Seller instance) : this(instance.name, instance.link)
        {

        }
        #endregion
    }
}
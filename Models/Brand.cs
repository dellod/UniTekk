using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models
{
    public class Brand
    {
        #region Properties
        /// <summary>
        /// Name of the brand.
        /// </summary>
        public string Name
        {
            get; set;
        }
        
        /// <summary>
        /// Unique brand ID.
        /// </summary>
        public int BrandID
        {
            get; set;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor (nescessary for deserialization).
        /// </summary>
        public Brand()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="name">Name of brand.</param>
        /// <param name="brandid">ID of brand.</param>
        public Brand(string name, int brandid)
        {
            Name = name;
            BrandID = brandid;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance">Instance of brand that is being copied.</param>
        public Brand(Brand instance) : this(instance.Name, instance.BrandID)
        {

        }
        #endregion
    }
}
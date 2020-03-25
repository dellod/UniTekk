using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models.Products
{
    public class TV : Product
    {
        public int HorizontalPixels
        {
            get; set;
        }

        public int VerticalPixels
        {
            get; set;
        }
    }
}
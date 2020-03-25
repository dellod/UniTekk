using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models
{
    public class Camera : Product
    {
        #region Properties
        /// <summary>
        /// Aperture of camera.
        /// </summary>
        public int Aperture
        {
            get; set;
        }

        /// <summary>
        /// Shutter speed of camera.
        /// </summary>
        public int ShutterSpeed
        {
            get; set;
        }
        #endregion

        #region Constructors
        #endregion

    }
}
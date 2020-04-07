using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniTekk.Models.Products
{
    public class Camera
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
        /// <summary>
        /// Default constructor (nescessary for deserialization).
        /// </summary>
        public Camera()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param Name="cameraName">Name of camera.</param>
        /// <param Name="cameraId">Product ID of camera.</param>
        /// <param Name="brand">Brand of camera.</param>
        /// <param Name="price">Price of camera.</param>
        /// <param Name="availability">Stock of specific camera.</param>
        /// <param Name="aperture">Aperture of camera.</param>
        /// <param Name="shutterSpeed">Shutter speed of camera.</param>
        public Camera(int aperture, int shutterSpeed) 
        {
            Aperture = aperture;
            ShutterSpeed = shutterSpeed;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param Name="instance">Instance of camera that is being copied.</param>
        public Camera(Camera instance) : this( instance.Aperture, instance.ShutterSpeed)
        {

        }

        #endregion

    }
}
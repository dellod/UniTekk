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
        /// <summary>
        /// Default constructor (nescessary for deserialization).
        /// </summary>
        public Camera()
        {

        }

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param name="cameraName">Name of camera.</param>
        /// <param name="productId">Product ID of camera.</param>
        /// <param name="brand">Brand of camera.</param>
        /// <param name="price">Price of camera.</param>
        /// <param name="availability">Stock of specific camera.</param>
        /// <param name="aperture">Aperture of camera.</param>
        /// <param name="shutterSpeed">Shutter speed of camera.</param>
        public Camera(string cameraName, int productId, Brand brand, double price, int availability, int aperture, int shutterSpeed) : base(cameraName, productId, brand, price, availability)
        {
            Aperture = aperture;
            ShutterSpeed = shutterSpeed;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="instance">Instance of camera that is being copied.</param>
        public Camera(Camera instance) : this(instance.Name, instance.ProductID, instance.ProductBrand, instance.Price, instance.Availability, instance.Aperture, instance.ShutterSpeed)
        {

        }

        #endregion

    }
}
namespace UniTekk.Models.Products
{
    public  class Product
    {
        #region Properties
        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name
        {
            get; set;
        }

        public int price
        {
            get; set;
        }

        public int availability
        {
            get; set;
        }

        public string username
        {
            get; set;
        }

        public Brand seller
        {
            get; set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor (nescessary for deserialization).
        /// </summary>

        /// <summary>
        /// Field constructor.
        /// </summary>
        /// <param Name="name">Name of product.</param>
        /// <param Name="productid">ID of product.</param>
        /// <param Name="productBrand">Brand of product.</param>
        /// <param Name="price">Price of product.</param>
        /// <param Name="availability">Stock of product.</param>
        public Product(string name, int price, int availability,string manage_username,Brand sell)
        {
            this.Name = name;
            this.price = price;
            this.availability = availability;
            seller = sell;
            username=  manage_username;
            
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param Name="instance">Instance of product that is being copied.</param>
        public Product(Product instance) : this(instance.Name, instance.price, instance.availability, instance.username, instance.seller)
        {

        }
        #endregion
    }
}
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniTekk.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UniTekk.Models.Products;

namespace UniTekk.Controllers
{
    public class HomeController : Controller
    {

        #region CAME WITH ASP NET VERSION 2.1
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult<String> Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
        /**
         * Input given by the user for password and username
         * Returns a 1 if the credentials verify to admin
         * Returns a 2 if the credentials verify to client
         * Returns a 0 if credentials failed
         */
        [HttpGet]
        [Route("GetLogin")]
        public ActionResult<IEnumerable<string>> GetValues([FromQuery] string username, [FromQuery] string password)
        {
            UniTekk.Models.DatabaseModel db = new DatabaseModel();
            int returnVal = db.returnLoginInfo(username, password, "returnVal");
            return new string[] { returnVal.ToString() };
        }
        /**
         * Input given by the user for price and address, client username should also be given by the frontend
         * postCriteria will sned these to the db model
         * it should return a 1 if everything was inserted successfully
         */
        [HttpPost]
        [Route("PostCriteria")]
        public string[] postCriteria([FromQuery] string clientUsername, [FromQuery] string price, [FromQuery] string type, [FromQuery] string address)
        {
            DatabaseModel db = new DatabaseModel();
            int returnVal = db.insertCriteriaInfo(clientUsername, address, Int32.Parse(price), type);
            return new string[] { returnVal.ToString() };
        }

        /**
         * Requires all necessary info of a product(type info like laptop RAM included) and the Id of the seller
         * Also requires Sells table information
         * A POST by an admin user, putting in all necessary information about the product and the product subtype(laptop,phone,etc.)
         * It should recieve a 1 if everything completes successfully.
         */
        [HttpPost]
        [Route("InsertPost")]
        public string[] insertPost([FromQuery] string username, [FromQuery] int sellerId,[FromQuery] int availability ,
                                   [FromQuery] int price, [FromQuery] string productName,  [FromQuery] string type, 
                                   [FromQuery] string attr1, [FromQuery] string attr2,   [FromQuery] string attr3, 
                                   [FromQuery] string attr4, [FromQuery] string attr5)
        {
            DatabaseModel db = new DatabaseModel();
            Seller sell = new Seller();
            sell.SellerId = sellerId;
            Product pro = new Product(productName,price,availability,username,sell);
            int returnVal = db.insertProductInfo(pro,type,attr1,attr2,attr3,attr4,attr5);
            return new string[] { returnVal.ToString() };
        }

        /**
         * A DELETE that will remove all associated tuples that has the productId within it. 
         * Deletes from the product table, its associated child table (Camera,Laptop,TV, etc.) and 
         * the sells table
         */
        [HttpDelete]
        [Route("DeletePost")]
        public string[] deletePost([FromQuery] int productId)
        {
            DatabaseModel db = new DatabaseModel();
            int returnVal = db.deleteProduct(productId);
            return new string[] { returnVal.ToString() };
        }
		
		[HttpPost]
        [Route("RegisterClient")]
        public string[] registerClient([FromQuery] string username, [FromQuery] string password, [FromQuery] string address)
        {
            DatabaseModel db = new DatabaseModel();
            int returnVal = db.registerClient(username, password, address);
            return new string[] { returnVal.ToString() };
        }

        /*
         * A POST by an admin user, putting all necessary information about a Seller into the database. Into Seller and Sells database.
         */
        [HttpPost]
        [Route("InsertSeller")]
        public string[] insertSeller([FromQuery] string username, [FromQuery] string sellerName, [FromQuery] string link,
                                     [FromQuery] string productName, [FromQuery] int availability, [FromQuery] int price)
        {
            DatabaseModel db = new DatabaseModel();
            int returnValue = db.insertSeller(username, sellerName, link, productName, availability, price);
            return new string[] { returnValue.ToString() };
        }

        /*
         * A DELETE that will remove tuples associated with sellerId from Sellers and Sell table.
         */
         [HttpDelete]
         [Route("DeleteSeller")]
         public string[] deleteSeller([FromQuery] int sellerId)
         {
            DatabaseModel db = new DatabaseModel();
            int returnValue = db.deleteSeller(sellerId);
            return new string[] { returnValue.ToString() };
         }
        
        /**
         * A PUT that will edit the details of a tuple associated with the productId in the Product or Sells table.
         */
        [HttpPut]
        [Route("ChangeProductDetails")]
        public string[] changeProductDetails([FromQuery] string type, [FromQuery] string username, [FromQuery] int productId, 
                                             [FromQuery] string productName, [FromQuery] int price, [FromQuery] int availability)
        {
            DatabaseModel db = new DatabaseModel();
            int returnValue = db.changeProductDetails(type, username, productId, productName, price, availability);
            return new string[] { returnValue.ToString() };
        }

        /**
         * A get that will compare products of the same type (ie. Camera, Phone, TV, or Laptop).
         */
        [HttpGet]
        [Route("CompareProducts")]
        public string compareProducts([FromQuery] string username, [FromQuery] string type, [FromQuery] string productName1, [FromQuery] string productName2)
        {
            DatabaseModel db = new DatabaseModel();
            string returnValue = JsonConvert.SerializeObject(db.compareProducts(username, type, productName1, productName2));
            return returnValue;
        }

        [HttpGet]
        [Route("BrowseProducts")]
        public string browseProducts([FromQuery] string username)
        {
            DatabaseModel db = new DatabaseModel();
            string returnVal = string.Empty;
            if (username == null)
            {
                returnVal = JsonConvert.SerializeObject(db.browseProducts());
            }
            else
            {
                returnVal = JsonConvert.SerializeObject(db.browseProducts(username));
            }
            return returnVal;
        }
    }
}

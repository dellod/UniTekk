using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniTekk.Models;
using Newtonsoft.Json.Linq;
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
        public string[] postCriteria([FromQuery] string clientUsername, [FromQuery] string price, [FromQuery] string address)
        {
            DatabaseModel db = new DatabaseModel();
            int returnVal = db.insertCriteriaInfo(clientUsername, address, Int32.Parse(price));
            return new string[] { returnVal.ToString() };
        }

        /**
         * 
         * A POST by an admin user, putting in all necessary information about the product and the product subtype(laptop,phone,etc.)
         * Admin should also put in all information of the brand and their information
         * It should recieve a 1 if everything completes successfully.
         */
        [HttpPost]
        [Route("InsertPost")]
        public string[] insertPost([FromQuery] string username, [FromQuery] string sellerName , [FromQuery] string link, 
                                   [FromQuery] int availability , [FromQuery] int price, [FromQuery] string productName,
                                   [FromQuery] string type, [FromQuery] string attr1, [FromQuery] string attr2, 
                                   [FromQuery] string attr3, [FromQuery] string attr4, [FromQuery] string attr5)
        {
            DatabaseModel db = new DatabaseModel();
            Seller sell = new Seller(sellerName, link);
            Product pro = new Product(productName,price,availability,username,sell);
            int returnVal = db.insertProductInfo(pro,type,attr1,attr2,attr3,attr4,attr5);
            return new string[] { returnVal.ToString() };
            return new string[] { "" };
        }
		
		[HttpPost]
        [Route("RegisterClient")]
        public string[] registerClient([FromQuery] string username, [FromQuery] string password, [FromQuery] string address)
        {
            DatabaseModel db = new DatabaseModel();
            int returnVal = db.registerClient(username, password, address);
            return new string[] { returnVal.ToString() };
        }

        [HttpPost]
        [Route("InsertSeller")]
        public string[] insertSeller([FromQuery] string username, [FromQuery] string sellerName, [FromQuery] string link,
                                     [FromQuery] string productName, [FromQuery] int availability, [FromQuery] int price)
        {
            DatabaseModel db = new DatabaseModel();
            int returnValue = db.insertSeller(username, sellerName, link, productName, availability, price);
            return new string[] { returnValue.ToString() };
        }

    }
}

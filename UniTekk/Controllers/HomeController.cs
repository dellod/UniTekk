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

        [HttpGet]
        [Route("GetLogin")]
        public ActionResult<IEnumerable<string>> GetValues([FromQuery] string username, [FromQuery] string password)
        {
            UniTekk.Models.DatabaseModel db = new DatabaseModel();
            int returnVal = db.returnLoginInfo(username, password, "returnVal");
            return new string[] { returnVal.ToString() };
        }

        [HttpPost]
        [Route("PostCriteria")]
        public string[] postCriteria([FromQuery] string clientUsername, [FromQuery] string price, [FromQuery] string address)
        {
            DatabaseModel db = new DatabaseModel();
            int returnVal = db.insertCriteriaInfo(clientUsername, address, Int32.Parse(price));
            return new string[] { returnVal.ToString() };
        }


        [HttpPost]
        [Route("InsertPost")]
        public string[] insertPost([FromQuery] string username, [FromQuery] string sellerName , [FromQuery] string link, 
                                   [FromQuery] int availability , [FromQuery] int price, [FromQuery] string productName,
                                   [FromQuery] string type, [FromQuery] string attr1, [FromQuery] string attr2, 
                                   [FromQuery] string attr3, [FromQuery] string attr4, [FromQuery] string attr5)
        {
            DatabaseModel db = new DatabaseModel();
            Brand brand = new Brand(sellerName, link);
            Product pro = new Product(productName,price,availability,username,brand);
            int returnVal = db.insertProductInfo(pro,type,attr1,attr2,attr3,attr4,attr5);
            return new string[] { returnVal.ToString() };
        }
    }
}

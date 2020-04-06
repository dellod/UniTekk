using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniTekk.Models;
using Newtonsoft.Json.Linq;

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
        public ActionResult<IEnumerable<string>> GetValues()
        {
            UniTekk.Models.DatabaseModel db = new DatabaseModel();
            int returnVal = db.returnLoginInfo("hello", "world", 10.ToString());
            return new string[] { returnVal.ToString() };
        }

        [HttpPost]
        [Route("PostCriteria")]
        public string[] postCriteria([FromBody] JObject emp)
        {
            string clientUsername = (string)emp["clientUsername"];
            string address = (string)emp["Address"];
            int price = (int)emp["price"];
            DatabaseModel db = new DatabaseModel();
            int returnVal = db.insertCriteriaInfo(clientUsername, address, price);
            return new string[] { returnVal.ToString() };
        }
    }
}

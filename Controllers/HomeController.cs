using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniTekk.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Route("GetLogin")]
        public ActionResult<IEnumerable<string>> GetValues()
        {
            DataBaseModel db = new DataBaseModel();
            int returnVal = db.returnLoginInfo("username","password",1);
            return new string[] {returnVal.ToString()};
        }

        [HttpPost]
        [Route("PostCriteria")]
        public int postCriteria([FromBody] JObject emp)
        {
            string clientUsername = (int)emp["clientUsername"];
            string address = (string)emp["Address"];
            int price = (int)emp["price"];
            DataBaseModel db = new DataBaseModel();
            int returnVal = db.insertCriteriaInfo(clientUsername, address, price);
            return new string[] { returnVal.toString()};

        }
    }
}
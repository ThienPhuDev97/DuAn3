
using PayCartOnline.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayCartOnline.Controllers
{
    public class HomeController : Controller
    {
        private Handle db = new Handle();
        public ActionResult Index()
        {
           
            int x = 1;
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
        public ActionResult Login()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string phone,string password)
        {
            var t = phone;
            var Denominations = db.ShowDenomination();
            
            var check2 = db.CheckUserLogin(t);
            if (String.IsNullOrEmpty(check2))
            {
                return View();
            }
            else
            {
              
                ViewBag.user = check2;
                return View();
            }
            
            
        }



    }
}
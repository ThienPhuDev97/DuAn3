
using PayCartOnline.Models;
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
        public ActionResult CheckLogin()
        {
            var phone = Request["phone"];
            var password = Request["password"];

            CheckUser isCheck = db.CheckUserLogin(phone, password);
            if (isCheck is null)
            {

                return RedirectToAction("Index");
            }
            else
            {
                Session["Account"] = isCheck.Role;

                return RedirectToAction("Index", "Admin", new { Area = "Admin" });

            }


        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }



    }
}
using PayCartOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayCartOnline.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }    
        public ActionResult AccountUser()
        {
            return View();
        }   
        public ActionResult HistoryDeal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePost(FormCollection fc)
        {
            var record = new Users();
            
            record.FullName = fc["fullname"].Trim();
            record.Address = fc["address"].Trim();
            record.Birthday = fc["birthday"].Trim();
            record.Gender= fc["gender"].Trim().Equals("Nam") ? 1 :2;
            record.Identity_people = Int32.Parse(fc["cmnd"].Trim());
            return View();
        }
    }
}
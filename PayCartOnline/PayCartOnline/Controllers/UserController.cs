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
            string _fullname = fc["fullname"].Trim();
            string _address = fc["address"].Trim();
            string _birthday = fc["birthday"].Trim();
            var record = new Users();
            record.FullName = _fullname;
            record.Address = _address;
            record.Birthday = _birthday;
            
            return View();
        }
    }
}
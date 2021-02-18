using PayCartOnline.Models;
using PayCartOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayCartOnline.Controllers
{
    public class UserController : Controller
    {
        Handle db = new Handle();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }    
        public ActionResult AccountUser()
        {
            CheckUser current =(CheckUser)Session["Account"];
            
            
            Users us = db.FindAccByID2(current.ID_User);
           
                return View();
        }   
        public ActionResult HistoryDeal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePost(FormCollection fc)
        {
            CheckUser currentUser = (CheckUser)Session["Account"];
            var record = new Users();
            record.ID = currentUser.ID_User;
            record.FullName = fc["fullname"].Trim();
            record.Address = fc["address"].Trim();
            record.Birthday = fc["birthday"].Trim();
            record.Gender= fc["gender"].Trim().Equals("Nam") ? 1 :2;
            record.Identity_people = Int32.Parse(fc["cmnd"].Trim());

            db.UpdateInformationUser(record);
            return RedirectToAction("AccountUser");
        }
    }
}
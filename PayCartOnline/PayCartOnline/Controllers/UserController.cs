using PayCartOnline.Areas.Admin.AttributeLogin;
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
            if ((CheckUser)Session["Account"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
                
        }
      
        public ActionResult AccountUser()
        {
            if ((CheckUser)Session["Account"] != null)
            {
                CheckUser current = (CheckUser)Session["Account"];


                Users us = db.FindAccByID2(current.ID_User);

                return View(us);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        //[CheckLogin]
        public ActionResult HistoryDeal(DateTime? startDate, DateTime? expirationDate, int? typePay)
        {
            if ((CheckUser)Session["Account"] != null)
            {
                CheckUser current = (CheckUser)Session["Account"];
                if (startDate != null || expirationDate != null || typePay != null)
                {
                    SearchHistory search = new SearchHistory
                    { ID_Acc = current.ID_User, startDate = startDate, expirationDate = expirationDate, typePay = typePay };

                    List<Order> data = db.SearchHistory(search);
                    ViewBag.startDate = startDate;
                    ViewBag.expirationDate = expirationDate;
                    ViewBag.typePay = typePay;
                    ViewBag.orders = data;
                    return View();
                }
                var orders = db.GetOrderByIDAcc(current.ID_User);
                ViewBag.orders = orders;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        [HttpPost]
        [CheckLogin]
        public ActionResult AccountUser(FormCollection fc)
        {
            if ((CheckUser)Session["Account"] != null)
            {
                CheckUser currentUser = (CheckUser)Session["Account"];
                var record = new Users();
                record.ID = currentUser.ID_User;
                record.FullName = fc["fullname"].Trim();
                record.Address = fc["address"].Trim();
                record.Birthday = fc["birthday"].Trim();
                record.Gender = fc["gender"].Trim().Equals("Nam") ? 1 : 2;
                record.Identity_people = Int32.Parse(fc["cmnd"].Trim());

                if (ModelState.IsValid)
                {
                    db.UpdateInformationUser(record);
                    return RedirectToAction("AccountUser");
                }
                return View(record);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
               

        }


        [HttpGet]
     
        public ActionResult DetailsOrder(int id)
        {
            if ((CheckUser)Session["Account"] != null)
            {
                Order order = db.SearchOrder(id);
                ViewBag.order = order;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
                
        }
    }
}
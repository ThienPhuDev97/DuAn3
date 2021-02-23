using PayCartOnline.Models;
using PayCartOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayCartOnline.Areas.Admin.Controllers
{
    public class DenominationController : Controller
    {
        HandleDenomination hd = new HandleDenomination();
        // GET: Admin/Denomination
        public ActionResult Index()
        {
            List<Denomination> denominations = hd.ShowDenomination();
            ViewBag.deno = denominations;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
    }
}
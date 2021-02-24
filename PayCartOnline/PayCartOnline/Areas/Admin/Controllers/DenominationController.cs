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
        HandleDenomination db = new HandleDenomination();
        // GET: Admin/Denomination
        public ActionResult Index(int? i, int? page)
        {
            List<Denomination> denominations = db.ShowDenomination();
            
            int pageSize = 5;

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int start = (int)(page - 1) * pageSize;

            ViewBag.pageCurrent = page;
            int totalPage = denominations.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.totalPage = totalPage;
            ViewBag.pageSize = pageSize;
            ViewBag.numSize = numSize;
            ViewBag.numSize = numSize;


            ViewBag.deno = denominations.OrderByDescending(x => x.ID).Skip(start).Take(pageSize);
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(string Price)
        {
            var price = Convert.ToInt32(Price);
            db.AddDenominations(price);
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
    }
}
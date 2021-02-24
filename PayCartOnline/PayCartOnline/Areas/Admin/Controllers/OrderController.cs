
using PayCartOnline.Models;
using PayCartOnline.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayCartOnline.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        Handle db = new Handle();
        // GET: Admin/Order
        public ActionResult Index()
        {
            int total = 0;
            int orderSuccess = 0;
            int order_Error = 0;
            List<Order> orders= db.ListOrder();
            int countOrder = orders.Count;
            foreach (var item in orders)
            {
                total += item.Total;
                _ = item.Status.Equals("Thành Công") ? orderSuccess++ : order_Error++;
            }
            ViewBag.orderSuccess = orderSuccess;
            ViewBag.order_Error = order_Error;
            ViewBag.total = total;
            ViewBag.count = countOrder;
            return View();
        }
    }
}
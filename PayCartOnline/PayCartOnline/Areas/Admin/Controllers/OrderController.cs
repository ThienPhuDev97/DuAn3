
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
        HandleOrder db = new HandleOrder();
        // GET: Admin/Order
        public ActionResult Index(int? i, int? page,DateTime? startDate,DateTime? expiration,int? status)
        {
            List<Order> orders = new List<Order>();
            if ((CheckUser)Session["Account"] != null)
            {
                if (startDate != null || expiration != null ||  status != null)
                {
                    SearchHistory search = new SearchHistory() { StartDate = startDate, ExpirationDate = expiration, Status = status };
                    orders = db.SearchOrder(search);

                }
                else
                {
                    orders = db.ListOrder();
                }
                int total = 0;
                int orderSuccess = 0;
                int order_Error = 0;
                //List<Order> orders = db.ListOrder();
                
                int countOrder = orders.Count;
                foreach (var item in orders)
                {

                    total += item.Status.Equals("Thành Công") ? item.Total : 0;
                    _ = item.Status.Equals("Thành Công") ? orderSuccess++ : order_Error++;
                }
                ViewBag.orderSuccess = orderSuccess;
                ViewBag.order_Error = order_Error;
                ViewBag.total = total;
                ViewBag.count = countOrder;

                //
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
                int totalPage = orders.Count();
                float totalNumsize = (totalPage / (float)pageSize);
                int numSize = (int)Math.Ceiling(totalNumsize);
                ViewBag.totalPage = totalPage;
                ViewBag.pageSize = pageSize;
                ViewBag.numSize = numSize;
                ViewBag.numSize = numSize;
                ViewBag.orders = orders.OrderByDescending(x => x.Id_order).Skip(start).Take(pageSize);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
            
        }
    }
}
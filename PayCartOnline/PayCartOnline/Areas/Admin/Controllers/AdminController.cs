using PayCartOnline.Areas.Admin.AttributeLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayCartOnline.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [CheckLogin]
        public ActionResult Index()
        {
            return View();
        }
    }
}
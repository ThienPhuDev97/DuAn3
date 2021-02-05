using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayCartOnline.Areas.Admin.AttributeLogin
{
    public class CheckLogin : ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //kiem tra dang nhap
            if (HttpContext.Current.Session["Account"] == null || HttpContext.Current.Session["Account"].Equals("User"))
            {
                HttpContext.Current.Response.Redirect("/Home/Index");
                base.OnActionExecuting(filterContext);
            }
            

        }
    }
}
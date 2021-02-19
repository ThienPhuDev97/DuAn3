using PayCartOnline.Models;
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
            CheckUser user = (CheckUser)HttpContext.Current.Session["Account"];
            if ( user == null || user.Role.Equals("User"))
            {
                // chay vao day mà k chuyển trang nữa nhỉ còn sang cổnller
                HttpContext.Current.Response.Redirect("/Home/Index");
                base.OnActionExecuting(filterContext);
            }
       


        }
    }
}
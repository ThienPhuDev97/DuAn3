
using PayCartOnline.Models;
using PayCartOnline.Models.VNPAY;
using PayCartOnline.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayCartOnline.Controllers
{
    public class HomeController : Controller
    {
        private Handle db = new Handle();
        public ActionResult Index()
        {
           
            int x = 1;
            return View();
        }

        public ActionResult About(VnPayResponse nong)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
           

            return View();
        }
        public ActionResult Register()
        {

            ViewBag.arr_phone = db.ListPhone();
            return View();
        }
        [HttpPost]
        public ActionResult Register2()
        {
            var phone = Request["phone"];
            var pass = Request["password"];
            DateTime create_at = DateTime.Now;
            db.RegisterAcc(phone, pass, create_at);
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CheckLogin()
        {
            var phone = Request["phone"];
            var password = Request["password"];

            CheckUser isCheck = db.CheckUserLogin(phone, password);
            if (isCheck is null)
            {

                return RedirectToAction("Index");
            }
            else
            {
                Session["Account"] = isCheck.Role;

                return RedirectToAction("Index", "Admin", new { Area = "Admin" });

            }


        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Pay()
        {
            //doan nay k can dung k a
            var phone = Request["phone"];
            var menhgia = Request["menhgia"];
            var nhamang = Request["nhamang"];
            var type = Request["type"];
            //Get Config Info
            // phần bên dưới này để sang actionresult khác
            string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma website
            string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat

            //Get payment input
            OrderInfo order = new OrderInfo();
            //Save order to db
            order.OrderId = DateTime.Now.Ticks;
            order.Phone = 0904448044;
            order.Amount = 1000000;
            order.OrderDescription = "124124";
            //order.Amount = Convert.ToDecimal(Request.QueryString["Amount"]);
            //order.OrderDescription = Request.QueryString["OrderDescription"];
            order.CreatedDate = DateTime.Now;

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", "2.0.0");
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);

            string locale = "vn";//"en"
            if (!string.IsNullOrEmpty(locale))
            {
                vnpay.AddRequestData("vnp_Locale", locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }

            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());
            vnpay.AddRequestData("vnp_Phone",order.Phone.ToString());
            vnpay.AddRequestData("vnp_OrderInfo", order.OrderDescription);
            vnpay.AddRequestData("vnp_OrderType", "insurance"); //default value: other
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_IpAddr", GetIpAddress());
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            //if (bank.SelectedItem != null && !string.IsNullOrEmpty(bank.SelectedItem.Value))
            //{
            //    vnpay.AddRequestData("vnp_BankCode", bank.SelectedItem.Value);
            //}
            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            ViewBag.demoUrl = paymentUrl;
            //log.InfoFormat("VNPAY URL: {0}", paymentUrl);
            //dynamic data = new ExpandoObject();
            //data.vnpay = vnpay;
            return View();
        }
        public ActionResult Test(VnPayResponse nong)
        {
            ViewBag.phi = nong;
            return View();
        }
        public string GetIpAddress()
        {
            string ipAddress;
            try
            {
                ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() == "unknown"))
                    ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            catch (Exception ex)
            {
                ipAddress = "Invalid IP:" + ex.Message;
            }

            return ipAddress;
        }

        //
      
        public ActionResult ReceiveInfo()
        {
            var phone = Request["phone"];
            var menhgia = Request["menhgia"];
            var nhamang = Request["nhamang"];
            var type = Request["type"];

            ViewBag.mobile = Request["mobile"];
            ViewBag.menhgia = Request["menhgia"];
            ViewBag.nhamang = Request["nhamang"];
            ViewBag.type = Request["type"];

            string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma website
            string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat

            //Get payment input
            OrderInfo order = new OrderInfo();
            //Save order to db
            order.OrderId = DateTime.Now.Ticks;
            order.Phone = Convert.ToInt32( Request["mobile"].ToString());
            order.Amount = Convert.ToInt32(Request["menhgia"].ToString());
            order.OrderDescription = "aloalo thanh toan";
            //order.Amount = Convert.ToDecimal(Request.QueryString["Amount"]);
            //order.OrderDescription = Request.QueryString["OrderDescription"];
            order.CreatedDate = DateTime.Now;

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", "2.0.0");
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);

            string locale = "vn";//"en"
            if (!string.IsNullOrEmpty(locale))
            {
                vnpay.AddRequestData("vnp_Locale", locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }

            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());
            vnpay.AddRequestData("vnp_Phone", order.Phone.ToString());
            vnpay.AddRequestData("vnp_OrderInfo", order.OrderDescription);
            vnpay.AddRequestData("vnp_OrderType", "insurance"); //default value: other
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_IpAddr", GetIpAddress());
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            //if (bank.SelectedItem != null && !string.IsNullOrEmpty(bank.SelectedItem.Value))
            //{
            //    vnpay.AddRequestData("vnp_BankCode", bank.SelectedItem.Value);
            //}
            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            ViewBag.demoUrl = paymentUrl;



            return View();
        }


    }
}
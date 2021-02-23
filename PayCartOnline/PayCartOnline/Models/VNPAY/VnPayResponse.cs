using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayCartOnline.Models.VNPAY
{
    public class VnPayResponse
    {
        public string vnp_ResponseCode { get; set; }
        public int vnp_Amount { get; set; }
        public string vnp_BankCode { get; set; }
        public string vnp_CardType { get; set; }
        public string vnp_PayDate { get; set; }
        public string vnp_OrderInfo { get; set; }
        public string vnp_Command { get; set; }
    }
}
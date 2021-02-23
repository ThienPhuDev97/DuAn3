using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayCartOnline.Models
{
    public class Order
    {
        public int Id_order { get; set; }
        public string Code_Order { get; set; }
        public int Phone { get; set; }
        public string Brand { get; set; }
        public int Total { get; set; }
        public string CardType { get; set; }
        public string BankCode { get; set; }
        public DateTime Create_At { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public int ID_Denomination { get; set; }
    }
}
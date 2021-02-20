using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayCartOnline.Models
{
    public class SearchHistory
    {
        public int? ID_Acc { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? expirationDate { get; set; }
        public int? typePay { get; set; }

       

    }
}
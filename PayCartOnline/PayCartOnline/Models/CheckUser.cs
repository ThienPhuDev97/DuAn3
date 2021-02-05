using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayCartOnline.Models
{
    public class CheckUser
    {
        public int? ID_User { get; set; }
        public string Role { get; set; } = null;
        public string Phone { get; set; } = null;
        public string UserName { get; set; }
        public string Pwd { get; set; } = null;
        public string Status{ get; set; } = null;
        public DateTime? Create_At { get; set; }
    }
}
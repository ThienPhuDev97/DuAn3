using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayCartOnline.Models
{
    public class Users
    {
      
       
        public int? ID { get; set; }
        public string UserName { get; set; } = null;
     
        public string Password { get; set; }
        
        public string Phone { get; set; }
        public string FullName { get; set; } = null;
        public string Email { get; set; } = null;
        public string Address { get; set; } = null;
        public string Birthday { get; set; } = null;
        public string ImageFace { get; set; } = null;
        public int Identity_people { get; set; }
        public int Gender { get; set; }

        public string Status { get; set; }
      
        public DateTime? Create_At { get; set; }
      
    }
}
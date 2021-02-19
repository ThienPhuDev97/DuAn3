using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Họ và tên")]
        [Required]
        public string FullName { get; set; } = null;
        public string Email { get; set; } = null;
        [DisplayName("Địa chỉ")]
        [Required]
        public string Address { get; set; } = null;
        [DisplayName("Ngày sinh")]
        [Required]
        public string Birthday { get; set; } = null;
        public string ImageFace { get; set; } = null;
        [DisplayName("Căn cước")]
        [Required]
        public int Identity_people { get; set; }
        [DisplayName("Giới tính")]
        [Required]
        public int Gender { get; set; }

        public string Status { get; set; }
      
        public DateTime? Create_At { get; set; }
      
    }
}
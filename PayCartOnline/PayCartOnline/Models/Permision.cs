using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayCartOnline.Models
{
    public class Permision
    {
        [Key]
        public int ID { get; set; }
        
        public int? Role_ID { get; set; }
        public int? User_ID { get; set; }

        
        // cái này nó tự sinh ra vào db ý

        //public virtual Roles Roles { get; set; }
        //public virtual Users Users { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task_Back_End.Models
{
    public class Product
    {   
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productID { get; set; }
        [Required]
        public string productName { get; set; }
        public int userID { get; set; }
        [Required]
        public int stock { get; set; }
        public virtual User Kullanici { get; set; }
    }

    
}
 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_Back_End.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        [Required]
        public string mailAdress { get; set; }
        [Required]
        public int password { get; set; }
        [Required]
        public bool role { get; set; }

        public virtual List<Product> Urunler { get; set; }
        public virtual List<Transaction> Islemler { get; set; }
    }
}
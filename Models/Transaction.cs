using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task_Back_End.Models
{
    public class Transaction
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transactionID { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        [Required]
        public int count { get; set; }
        [Required]
        public int orderNo { get; set; }
        [Required]
        public DateTime timeStamp { get; set; }

        public virtual List<Product> Urunler { get; set; }
    }
}
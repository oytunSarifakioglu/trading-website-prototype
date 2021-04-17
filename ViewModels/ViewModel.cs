using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_Back_End.Models;

namespace Task.Views
{
    public class ViewModel
    {
        public List<User> İnsanlar { get; set; }
        public List<Transaction> Siparisler { get; set; }
        public List<Product> Ürünler { get; set; }
    }
}
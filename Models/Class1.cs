using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Task_Back_End.Models
{
    public class Urun
    {
        public int id { get; set; }
        public string urunAd { get; set; }
        public int urunMiktar { get; set; }


        public static List<Urun> UrunleriGoster(){

            return new List<Urun>()
            {
                new Urun(){id=4, urunAd="Silgi" ,urunMiktar=1},
                new Urun(){id=5, urunAd="Defter" ,urunMiktar=5},
                new Urun(){id=6, urunAd="Pilot Kalem" ,urunMiktar=4},
                new Urun(){id=7, urunAd="Bant" ,urunMiktar=2},
            };
        }
    }
}
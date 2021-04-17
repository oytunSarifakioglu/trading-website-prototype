using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using Task.Views;
using Task_Back_End.Models;
using Task_Back_End.Models.DBMS;

namespace Task_Back_End.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult login()
        {          
            return View(new User());
        }
        [HttpPost]
        public ActionResult login(User model)
        {
            DBcontext db = new DBcontext();
            User user = db.User.FirstOrDefault(x => x.mailAdress == model.mailAdress && x.password == model.password && x.role == model.role);
            if (user == null)
            {
                ModelState.AddModelError("", "Hatalı Giriş Yaptınız!");
                return View(model);
            }
            else if( model.role == false)
            {
                
                Session["login"] = user;
                return RedirectToAction("müşteri");
            }
            else if(model.role == true)
            {
                Session["login"] = user;
                return RedirectToAction("mağaza");
            }
            return View();
        }
        public ActionResult mağaza()
        {
            return View();
        }
        public ActionResult müşteri()
        {
            SelectList dropdownMenu = new SelectList(Urun.UrunleriGoster(), "urunMiktar", "urunAd");
            ViewBag.UrunData = dropdownMenu;
            return View();
        }
        public ActionResult rapor()
        {
            DBcontext db = new DBcontext();
            ViewModel model = new ViewModel();
            model.Ürünler = db.Product.ToList();
            return View(model);

            
        }
        public ActionResult sepet()
        {
            DBcontext db = new DBcontext();
            ViewModel model = new ViewModel();

       
            return View(); 
        }
        public ActionResult dbbagla()
        {
            DBcontext db = new DBcontext();
            ViewModel model = new ViewModel();

            model.İnsanlar = db.User.ToList();
            model.Siparisler = db.Transaction.ToList();

            return View(model);
        }
        public ActionResult gecmisSiparisler()
        {
            DBcontext db = new DBcontext();
            ViewModel model = new ViewModel();
            model.Siparisler = db.Transaction.ToList();
            return View(model);
        }
        public ActionResult kisiBazlıSiparis()
        {
            DBcontext db = new DBcontext();
            ViewModel model = new ViewModel();
            model.Siparisler = db.Transaction.ToList();
            return View(model);
        }
        public ActionResult urunBazliSatis()
        {
            DBcontext db = new DBcontext();
            ViewModel model = new ViewModel();
            model.Ürünler = db.Product.ToList();
            return View(model);
        }
    }
}
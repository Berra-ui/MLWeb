using MLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MLWeb.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        MLWebEntities db = new MLWebEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admins ad)
        {
            var bilgiler = db.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre==ad.Sifre);
            if(bilgiler != null)
            {
                if (ad.Sifre==bilgiler.Sifre)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                    Session["Kullanici"] = bilgiler.Kullanici.ToString();
                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    return View();
                }
                

            }
            else { return View(); }
        
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","GirisYap");
        }
    }
}
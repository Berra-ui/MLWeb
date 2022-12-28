using MLWeb.Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MLWebEntities db = new MLWebEntities();
        [Authorize]

        public ActionResult Index()
        {

            List<HomeSViewModel> model = new List<HomeSViewModel>();

            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }


                var tb = db.HomeS.ToList();
                foreach (var a in tb)
                {
                    HomeSViewModel s = new HomeSViewModel();
                    s.id = a.id;
                    s.img = a.img;
                    s.Text = a.Text;
                    s.Lang = a.Lang;
                    model.Add(s);
                    ViewBag.kategori = s.Lang;

                }

              
                return View(model);

            }

        }
        [Authorize]
        public ActionResult HomeA()
        {
            List<HomeAViewModel> model = new List<HomeAViewModel>();

            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }


                var tb = db.HomeA.ToList();
                foreach (var a in tb)
                {
                    HomeAViewModel s = new HomeAViewModel();
                    s.id = a.id;
                    s.img = a.img;
                    s.Text = a.Text;
                    s.Lang = a.Lang;
                    s.Caption = a.Caption;
                    model.Add(s);

                }
                return View(model);

            }

        }
        [Authorize]
        public ActionResult urunler()
        {
            List<ProductsViewModel> model = new List<ProductsViewModel>();

            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }


                var tb = db.Products.ToList();
                foreach (var a in tb)
                {
                    ProductsViewModel s = new ProductsViewModel();

                    s.Lang = a.Lang;
                    s.ID = a.ID;
                    s.Caption = a.Caption;
                    s.explanation = a.explanation;
                    s.Urunimg = a.Urunimg;
                    s.Tablo = a.Tablo;
                    model.Add(s);

                }
                return View(model);

            }

        }
        [Authorize]

        public ActionResult UrunlerGetir(int ID)
        {
            ProductsViewModel model = new ProductsViewModel();
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }

                var tb = db.Products.Where(x => x.ID == ID).FirstOrDefault();
                model.Lang = tb.Lang;
                model.Caption = tb.Caption;
                model.explanation = tb.explanation;
                model.Urunimg = tb.Urunimg;
                model.Tablo = tb.Tablo;
              

            }
            List<SelectListItem> langlist = (from a in db.Language.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = a.DilKodu,
                                                 Value = a.DilKodu.ToString()
                                             }).ToList();
            ViewBag.lang = langlist;

            db.SaveChanges();
            return View(model);
        }
        [Authorize]
        public ActionResult iletisim()
        {
            List<ContactViewModel> model = new List<ContactViewModel>();

            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }


                var tb = db.Contact.ToList();
                foreach (var a in tb)
                {
                    ContactViewModel s = new ContactViewModel();

                    s.Lang = a.Lang;
                    s.Adres = a.Adres;
                    s.ID = a.ID;
                    s.Aciklama = a.Aciklama;
                    s.Baslik = a.Baslik;
                    s.Tel = a.Tel;
                    s.Mail = a.Mail;
                    s.Map = a.Map;
                    model.Add(s);

                }
                ViewBag.mod = model;
                return View(model);

            }

        }
        [Authorize]

        public ActionResult About()
        {
            List<AboutPageViewModel> model = new List<AboutPageViewModel>();
            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.AboutPage.ToList();

                foreach (var item in tb)
                {
                    AboutPageViewModel satir = new AboutPageViewModel();

                    satir.ID = item.ID;
                    satir.Lang = item.Lang;
                    satir.AText = item.AText;
                    satir.AboutPageimg = item.AboutPageimg;
                    satir.Lang = item.Lang;
                    satir.AboutPageimg = item.AboutPageimg;
                    satir.AboutExpCap = item.AboutExpCap;
                    satir.AboutExp = item.AboutExp;
                    satir.ABaslik = item.ABaslik;


                    model.Add(satir);
                }
                return View(model);
            }
        }
        [Authorize]

        [ValidateInput(false)]
        public ActionResult SlideEkle()
        {
            List<SelectListItem> langlist = (from a in db.Language.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = a.DilKodu,
                                                 Value = a.DilKodu.ToString()
                                             }).ToList();
            ViewBag.lang = langlist;

            return View();
        }

        [Authorize]

        public ActionResult iletisimgetir(int id, Contact c)
        {
            ContactViewModel model = new ContactViewModel();
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.Contact.Where(x => x.ID == id).FirstOrDefault();
                model.ID = tb.ID;
                model.Adres = tb.Adres;
                model.Aciklama = tb.Aciklama;
                model.Baslik = tb.Baslik;
                model.Mail = tb.Mail;
                model.Tel = tb.Tel;
                model.Lang = tb.Lang;
                model.Map = tb.Map;

            }
          
            db.SaveChanges();
            return View(model);
        }
        [Authorize]
        public ActionResult HomeAGetir(int id, HomeA a)
        {
            HomeAViewModel model = new HomeAViewModel();

            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.HomeA.Where(x => x.id == id).FirstOrDefault();
                model.id = tb.id;
                model.Caption = tb.Caption;
                model.img = tb.Caption;
                model.Lang = tb.Lang;
                model.Text = tb.Text;
            }

            db.SaveChanges();
            return View(model);

        }
        [Authorize]
        [HttpPost, ValidateInput(false)]

        public ActionResult iletisimguncelle(Contact c)
        {
            ContactViewModel model = new ContactViewModel();
            int ID = c.ID;
            var tb = db.Contact.Where(x => x.ID == ID).FirstOrDefault();

            if (tb != null)
            {
                tb.Adres = c.Adres;
                tb.Lang = c.Lang;
                tb.Baslik = c.Baslik;
                tb.Aciklama = c.Aciklama;
                tb.ID = c.ID;
                tb.Mail = c.Mail;
                tb.Tel = c.Tel;
                tb.Map = c.Map;


                db.SaveChanges();

            }


            return RedirectToAction("iletisim");

        }
        [Authorize]



        public ActionResult hakkimizdagetir(int id)
        {
            AboutPageViewModel model = new AboutPageViewModel();



            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }


                var tb = db.AboutPage.Where(x => x.ID == id).FirstOrDefault();

                model.AText = tb.AText;
                model.AboutExp = tb.AboutExp;
                model.ID = tb.ID;
                model.AboutPageimg = tb.AboutPageimg;
                model.ABaslik = tb.ABaslik;
                model.AboutExpCap = tb.AboutExpCap;
                model.Lang = tb.Lang;


            }


            db.SaveChanges();
            return View(model);

        }
        [Authorize]


        [HttpPost, ValidateInput(false)]
        public ActionResult SlideGuncelle(HomeS p)
        {
            HomeSViewModel model = new HomeSViewModel();

            int id = p.id;

            var tb = db.HomeS.Where(x => x.id == id).FirstOrDefault();


            if (tb != null)
            {
                tb.Text = p.Text;
                tb.Lang = p.Lang;
                if (p.img != null)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/img/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    tb.img = "/img/" + dosyaadi + uzanti;
                }
                var sld = db.Language.Where(x => x.ID == p.id).SingleOrDefault();

                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult hakkimizdaguncelle(AboutPage p)
        {

            int ID = p.ID;
            var tb = db.AboutPage.Where(x => x.ID == ID).FirstOrDefault();
            if (tb != null)
            {
                tb.AText = p.AText;
                tb.AboutExp = p.AboutExp; 
                tb.ID = p.ID;
                tb.ABaslik = p.ABaslik;
                tb.AboutExpCap = p.AboutExpCap;
                tb.Lang = p.Lang;
                if (p.AboutPageimg != null)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/img/" + dosyaadi;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    tb.AboutPageimg = "/img/" + dosyaadi;
                }
                db.SaveChanges();
            }
            return RedirectToAction("About");
        }
        [Authorize]
        [ValidateInput(false)]
        public ActionResult SlideGetir(int id, HomeS p)
        {
            HomeSViewModel model = new HomeSViewModel();


            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }


                var tb = db.HomeS.Where(x => x.id == id).FirstOrDefault();

                model.Lang = tb.Lang;
                model.img = tb.img;
                model.Text = tb.Text;
                model.id = tb.id;


            }

            List<SelectListItem> langlist = (from a in db.Language.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = a.DilKodu,
                                                 Value = a.DilKodu.ToString()
                                             }).ToList();
            ViewBag.lang = langlist;
            db.SaveChanges();
            return View(model);

        }
        [Authorize]
        [HttpPost, ValidateInput(false)]

        public ActionResult SlideEkle(HomeS p)
        {
            HomeSViewModel model = new HomeSViewModel();
            int id = p.id;

            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }



                if (p.img != null)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/img/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.img = "/img/" + dosyaadi + uzanti;
                }
                List<SelectListItem> langlist = (from a in db.Language.ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = a.DilKodu,
                                                     Value = a.DilKodu.ToString()
                                                 }).ToList();
                ViewBag.lang = langlist;


                db.HomeS.Add(p);

                db.SaveChanges();
            }



            return RedirectToAction("Index");
        }
        [Authorize]
        [ValidateInput(false)]
        public ActionResult urunekle()
        {
            List<SelectListItem> langlist = (from a in db.Language.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = a.DilKodu,
                                                 Value = a.DilKodu.ToString()
                                             }).ToList();
            ViewBag.lang = langlist;

            return View();
        }
        [Authorize]
        [HttpPost,ValidateInput(false)]
        public ActionResult urunekle(Products p)
        {
            ProductsViewModel model = new ProductsViewModel();
            int ID = p.ID;
         

            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }



                if (p.Urunimg != null)
                {
                    string yeniisim = p.ID.ToString();
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/img/" +  yeniisim + dosyaadi;
                     Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.Urunimg = "/img/" + yeniisim + dosyaadi ;
                }
                if (p.Tablo != null)
                {
                    string yeniisim = p.ID.ToString();

                    string dosyaadi = Path.GetFileName(Request.Files[1].FileName);
                    string uzanti = Path.GetExtension(Request.Files[1].FileName);
                    string yol = "~/img/" +yeniisim + dosyaadi;
                    Request.Files[1].SaveAs(Server.MapPath(yol));
                    p.Tablo = "/img/" + yeniisim + dosyaadi ;
                }
                List<SelectListItem> langlist = (from a in db.Language.ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = a.DilKodu,
                                                     Value = a.DilKodu.ToString()
                                                 }).ToList();
                ViewBag.lang = langlist;


                db.Products.Add(p);

                db.SaveChanges();
            }
           

            return RedirectToAction("urunler");
        }
        [Authorize]

        public ActionResult UrunSil(int id)
        {
            var u = db.Products.Find(id);
            db.Products.Remove(u);
            db.SaveChanges();
            return RedirectToAction("Urunler");
        }
        [Authorize]

        public ActionResult SlideSil(int id)
        {

            var b = db.HomeS.Find(id);
            db.HomeS.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult HomeASil(int id)
        {
            var a = db.HomeA.Find(id);
            db.HomeA.Remove(a);
            db.SaveChanges();
            return RedirectToAction("HomeA");
        }
        [Authorize]



        [HttpPost, ValidateInput(false)]
        public ActionResult UrunGuncelle(Products p)
        {
            ProductsViewModel model = new ProductsViewModel();
            var y = Request.Files;
            int id = p.ID;

            var tb = db.Products.Where(x => x.ID == id).FirstOrDefault();


            if (tb != null)
            {
                tb.Caption = p.Caption;
                tb.Lang = p.Lang;
                tb.explanation = p.explanation;

                if (p.Urunimg != null)
                {
                    string yeniisim = p.ID.ToString();

                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/img/" +   yeniisim + dosyaadi;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    tb.Urunimg = "/img/" + yeniisim+ dosyaadi ;
                }
                if (p.Tablo != null)
                {
                    string yeniisim = p.ID.ToString();
                    string dosyaadi = Path.GetFileName(Request.Files[1].FileName);
                    string uzanti = Path.GetExtension(Request.Files[1].FileName);
                    string yol = "~/img/" + yeniisim + dosyaadi;
                    Request.Files[1].SaveAs(Server.MapPath(yol));
                    tb.Tablo = "/img/" + yeniisim+ dosyaadi;
                }
                var urn = db.Language.Where(x => x.ID == p.ID).SingleOrDefault();
                db.SaveChanges();
            }
            
            
           
      
            return RedirectToAction("urunler");
        }
        [Authorize]
        [HttpPost, ValidateInput(false)]

        public ActionResult HomeAGuncelle(HomeA a)
        {
            HomeAViewModel model = new HomeAViewModel();
            int id = a.id;

            var tb = db.HomeA.Where(x => x.id == id).FirstOrDefault();

            if (tb != null)
            {
                tb.id = a.id;
                tb.Caption = a.Caption;
                tb.Lang = a.Lang;
                tb.Text = a.Text;
                if (a.img != null)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/img/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    tb.img = "/img/" + dosyaadi + uzanti;

                }
                db.SaveChanges();
            }

            return RedirectToAction("HomeA");
        }

    }

} 
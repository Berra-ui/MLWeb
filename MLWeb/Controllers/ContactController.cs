using MLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ContactViewModel model = new ContactViewModel();

            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }


                var tb = db.Contact.Where(x => x.Lang == Lang).FirstOrDefault();
                model.Lang = tb.Lang;
                model.Adres = tb.Adres;
                model.ID=tb.ID;
                model.Aciklama=tb.Aciklama;
                model.Baslik = tb.Baslik;
                model.Tel=tb.Tel;
                model.Mail = tb.Mail;
                model.Map = tb.Map;

            }

            return View(model);
        }
        public PartialViewResult Partial1()
        {
            List<ContactViewModel> model = new List<ContactViewModel>();
            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.Contact.Where(x => x.Lang == Lang).ToList();

                foreach (var item in tb)
                {
                    ContactViewModel satir = new ContactViewModel();

                    satir.Lang = item.Lang;
                    satir.Adres = item.Adres;
                    satir.ID = item.ID;
                    satir.Aciklama = item.Aciklama;
                    satir.Baslik = item.Baslik;
                    satir.Tel = item.Tel;
                    satir.Mail = item.Mail;
                    satir.Map=item.Map;


                    model.Add(satir);
                }


            }

            return PartialView(model);
        }
    }
}
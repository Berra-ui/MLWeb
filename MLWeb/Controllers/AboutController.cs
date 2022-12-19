using MLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {

            List<AboutPageViewModel> model = new List<AboutPageViewModel>();
            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.AboutPage.Where(x => x.Lang == Lang).ToList();

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


            }

            return View(model);
        }
        public PartialViewResult Partial1()
        {
            List<AboutPageViewModel> model = new List<AboutPageViewModel>();
            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.AboutPage.Where(x => x.Lang == Lang).ToList();
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
                return PartialView(model);
            }



        }
    }
}

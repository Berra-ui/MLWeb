using MLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            HomeViewModel model = new HomeViewModel();

            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }


                var tb = db.Home.Where(x => x.Lang == Lang).FirstOrDefault();
                model.PText = tb.PText;
                model.Lang = tb.Lang;

            }

            return View(model);
        }

        public PartialViewResult Partial1()
        {
            List<HomeSViewModel> model = new List<HomeSViewModel>();
            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.HomeS.Where(x => x.Lang == Lang).ToList();

                foreach (var item in tb)
                {
                    HomeSViewModel satir = new HomeSViewModel();

                    satir.id = item.id;
                    satir.img = item.img;
                    satir.Text = item.Text;
                    satir.Lang = item.Lang;

                    model.Add(satir);
                }


            }

            return PartialView(model);
        }
        public PartialViewResult Partial2()
        {
            List<HomeAViewModel> model = new List<HomeAViewModel>();
            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.HomeA.Where(x => x.Lang == Lang).ToList();

                foreach (var item in tb)
                {
                    HomeAViewModel satir = new HomeAViewModel();

                    satir.id = item.id;
                    satir.img = item.img;
                    satir.Text = item.Text;
                    satir.Lang = item.Lang;
                    satir.Caption = item.Caption;

                    model.Add(satir);
                }


            }

            return PartialView(model);

        }
        public PartialViewResult Partial3()
        {
            List<ProductsViewModel> model = new List<ProductsViewModel>();
            using (MLWebEntities db = new MLWebEntities())
            {
                string Lang = "TR";

                if (Request.Cookies["Languages"] != null)
                {
                    Lang = Request.Cookies["Languages"].Value;
                }
                var tb = db.Products.Where(x => x.Lang == Lang).ToList();

                foreach (var item in tb)
                {
                    ProductsViewModel satir = new ProductsViewModel();

                    satir.ID = item.ID;
                    satir.Urunimg = item.Urunimg;
                    satir.Caption=item.Caption;
                    satir.Lang=item.Lang;
                    satir.explanation = item.explanation;
                    satir.Description = item.Description;

                    model.Add(satir);
                }


            }

            return PartialView(model);

        }


    }
}
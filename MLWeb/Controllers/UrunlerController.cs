using MLWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        public ActionResult Index()
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
                    satir.Urunimg=item.Urunimg;
                    satir.Caption= item.Caption;
                    satir.explanation = item.explanation;
                    satir.Description= item.Description;    
                    satir.Lang = item.Lang;
                    satir.Tablo=item.Tablo;
                    model.Add(satir);
                }


            }

            return PartialView(model);
        }
    }
}
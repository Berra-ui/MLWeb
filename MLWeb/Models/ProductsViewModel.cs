using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Models
{

    public class ProductsViewModel
    {
        public int ID { get; set; }
        [AllowHtml]
        public string Caption { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string Urunimg { get; set; }
        [AllowHtml]
        public string explanation { get; set; }
        public string Lang { get; set; }
        public string Tablo { get; set; }
    }
   
}
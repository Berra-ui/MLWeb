using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Models
{
    public class HomeViewModel
    {
        public int ID { get; set; }
        public string Lang { get; set; }
        [AllowHtml]
        public string PText { get; set; }
    }
}
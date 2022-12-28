using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Models
{
    public class HomeSViewModel
    {
       
            public int id { get; set; }
            public string Lang { get; set; }
        [AllowHtml]
        public string Text { get; set; }
            public string img { get; set; }
        public List<LanguageViewModel> dil { get; set; }

    }
}
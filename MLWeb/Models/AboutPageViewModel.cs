using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Models
{
    public class AboutPageViewModel
    {
        public int ID { get; set; }
        public string Lang { get; set; }
      
        public string AText { get; set; }
      
        public string AboutPageimg { get; set; }
        
        public string ABaslik { get; set; }
        [AllowHtml]
        public string AboutExp { get; set; }
        [AllowHtml]

        public string AboutExpCap { get; set; }
    
    }

}
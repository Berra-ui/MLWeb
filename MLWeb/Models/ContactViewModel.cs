using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Models
{
    public class ContactViewModel
    {
        
        public int ID { get; set; }
        [AllowHtml]
        public string Lang { get; set; }
        [AllowHtml]

        public string Baslik { get; set; }
        [AllowHtml]
        public string Aciklama { get; set; }
        [AllowHtml]
        public string Adres { get; set; }
        
        public string Tel { get; set; }
      
        public string Mail { get; set; }
        public string Map { get; set; }
    }
}
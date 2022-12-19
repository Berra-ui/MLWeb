using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MLWeb.Controllers
{
    public class LangController : Controller
    {
        // GET: Lang
        [AllowAnonymous] 
        public ActionResult Change(string ID)
        {

            string Lang = ID;
            if (!string.IsNullOrEmpty(Lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
            }

            HttpCookie cookie = new HttpCookie("Languages");
            cookie.Value = Lang;
            Response.Cookies.Add(cookie);

            return Content("OK");
        }
    }
}
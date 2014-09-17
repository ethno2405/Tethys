using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tethys.Notifier.Controllers
{
    public class LocalizationController : Controller
    {
        public ActionResult Index()
        {
            var ip = Request.UserHostAddress;
            ViewBag.Ip = ip;
            return View();
        }
    }
}
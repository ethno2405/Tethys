using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Web;
using System.Web.Mvc;
using Tethys.Notifier.Infrastructure;

namespace Tethys.Notifier.Controllers
{
    public class LocalizationController : Controller
    {
        public ActionResult Index()
        {
            var ip = Request.UserHostAddress;
            var mac = NativeMethods.GetMacAddress(ip);

            ViewBag.Ip = ip;
            ViewBag.Mac = mac;

            return View();
        }
    }
}
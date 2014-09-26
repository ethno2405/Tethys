using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tethys.Notifier.Infrastructure;
using Tethys.Notifier.Models.Responses;
using Tethys.Notifier.Services;
using Tethys.Notifier.ViewModels.Dashboard;

namespace Tethys.Notifier.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var isLocalized = false;

            if (Request.UserHostAddress != "::1")
            {
                var deviceService = new DeviceService();
                var mac = NativeMethods.GetMacAddress(Request.UserHostAddress);
                var device = await deviceService.Get(Request.UserHostAddress, mac);
                isLocalized = device.IsLocalized;
            }

            var callTypeService = new CallTypeService();
            var calltypes = await callTypeService.Get();
            var localizationResponse = Session["localization_response"] as LocalizationResponse;
            var message = string.Empty;

            if (localizationResponse != null)
            {
                message = localizationResponse.Message ?? string.Empty;
                Session["localization_response"] = null;
            }

            var model = new IndexViewModel
            {
                Message = message,
                IsLocalized = isLocalized,
                CallTypes = calltypes
            };

            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tethys.Notifier.Infrastructure;
using Tethys.Notifier.Models;
using Tethys.Notifier.Services;
using Tethys.Notifier.ViewModels.Localization;

namespace Tethys.Notifier.Controllers
{
    public class LocalizationController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var roomService = new RoomService();
            var rooms = await roomService.Get();

            var model = new LocalizationViewModel
            {
                Device = new Device
                {
                    Room = new Room
                    {
                        Department = new Department()
                    },
                    Location = new Location(),
                    IpAddress = Request.UserHostAddress,
                    MacAddress = NativeMethods.GetMacAddress(Request.UserHostAddress)
                },
                Rooms = rooms,
                Departments = rooms.Select(x => x.Department)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(LocalizationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var localizationService = new LocalizationService();

            var response = await localizationService.Localize(model.Device);

            return RedirectToAction("Index");
        }
    }
}
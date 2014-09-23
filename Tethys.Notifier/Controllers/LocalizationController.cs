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
            Session["Rooms"] = rooms;

            var model = new LocalizationViewModel
            {
                IpAddress = Request.UserHostAddress,
                MacAddress = NativeMethods.GetMacAddress(Request.UserHostAddress),
                Departments = rooms.Select(x => x.Department).DistinctBy(x => x.Name)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(LocalizationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var rooms = Session["Rooms"] as IList<Room>;
                if (rooms == null)
                {
                    rooms = new List<Room>();
                }

                model.Departments = rooms.Select(x => x.Department).DistinctBy(x => x.Name);

                return View(model);
            }

            var device = new Device
            {
                Name = model.DeviceName,
                IpAddress = model.IpAddress,
                MacAddress = model.MacAddress,
                Location = new Location
                {
                    Name = model.SelectedLocationName
                },
                Room = new Room
                {
                    Name = model.SelectedRoomName,
                    Department = new Department
                    {
                        Name = model.SelectedDepartmentName
                    }
                }
            };

            var localizationService = new LocalizationService();

            var response = await localizationService.Localize(device);

            return RedirectToAction("Index");
        }
    }
}
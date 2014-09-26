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
            var ipAddress = Request.UserHostAddress;
            var macAddress = NativeMethods.GetMacAddress(ipAddress);
            var deviceService = new DeviceService();
            if (ipAddress != "::1")
            {
                var device = await deviceService.Get(ipAddress, macAddress);

                if (device != null && device.IsLocalized)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            var roomService = new RoomService();
            var rooms = await roomService.Get();

            Session["Rooms"] = rooms;

            var model = new LocalizationViewModel
            {
                IpAddress = ipAddress,
                MacAddress = macAddress,
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
            Session["localization_response"] = response;

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
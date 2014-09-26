using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.Infrastructure;
using Tethys.Observer.ViewModels.Device;

namespace Tethys.Observer.Controllers
{
    [RequireAuthorization]
    public class DeviceController : BaseController
    {
        public ActionResult List()
        {
            var model = new DevicesViewModel
            {
                Devices = Context.Devices.ToList()
            };

            return View(model);
        }

        public ActionResult Unlocalize(Guid id)
        {
            var device = Context.Devices.FirstOrDefault(x => x.Id == id);
            if (device == null)
            {
                return HttpNotFound();
            }

            var deviceService = new DeviceService(Context);
            deviceService.Unlocalize(device);

            return RedirectToAction("List");
        }
    }
}
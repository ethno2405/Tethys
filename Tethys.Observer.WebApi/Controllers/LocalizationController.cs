using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tethys.Observer.Domain.Entities;
using Tethys.Observer.WebApi.Models.Responses;

namespace Tethys.Observer.WebApi.Controllers
{
    public class LocalizationController : BaseApiController
    {
        public LocalizationResponse Localize(Device device)
        {
            if (device.Room == null)
            {
                return new LocalizationResponse("Unknown device room");
            }

            if (device.Location == null)
            {
                return new LocalizationResponse("Unknown device location");
            }

            var existingDevice = Context.Devices.FirstOrDefault(x => x.Id == device.Id) ?? new Device();

            existingDevice.Room = device.Room;
            existingDevice.Location = device.Location;

            try
            {
                Context.SaveChanges();
                return new LocalizationResponse(string.Format("Device {0} localized in department {1}, room {2}, location {3}", existingDevice.Name, existingDevice.Room.Department.Name, existingDevice.Room.Name, existingDevice.Location.Name));
            }
            catch (Exception ex)
            {
                return new LocalizationResponse(ex);
            }
        }
    }
}
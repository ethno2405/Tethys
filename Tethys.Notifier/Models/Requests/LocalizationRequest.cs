using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Notifier.Models.Requests
{
    public class LocalizationRequest
    {
        public LocalizationRequest(Device device)
        {
            if (device == null) throw new ArgumentNullException("device");

            Department = device.Room.Department.Name;
            IpAddress = device.IpAddress;
            IsLocalized = device.IsLocalized;
            Location = device.Location.Name;
            MacAddress = device.MacAddress;
            Name = device.Name;
            Room = device.Room.Name;
        }

        public string Department { get; private set; }

        public string IpAddress { get; private set; }

        public bool IsLocalized { get; private set; }

        public string Location { get; private set; }

        public string MacAddress { get; private set; }

        public string Name { get; private set; }

        public string Room { get; private set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Notifier.Models
{
    public class Room
    {
        public Department Department { get; set; }

        public IEnumerable<Device> Devices { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        public string Name { get; set; }
    }
}
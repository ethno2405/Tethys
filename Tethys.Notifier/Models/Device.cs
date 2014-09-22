using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Tethys.Notifier.Models
{
    public class Device
    {
        [DisplayName("IP")]
        public string IpAddress { get; set; }

        public Location Location { get; set; }

        [DisplayName("MAC")]
        public string MacAddress { get; set; }

        public string Name { get; set; }

        public Room Room { get; set; }
    }
}
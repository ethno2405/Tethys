using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Observer.Models.WebApi.Requests
{
    public class LocalizationRequest
    {
        public string Department { get; set; }

        public string IpAddress { get; set; }

        public bool IsLocalized { get; set; }

        public string Location { get; set; }

        public string MacAddress { get; set; }

        public string Name { get; set; }

        public string Room { get; set; }
    }
}
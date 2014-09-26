using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.WebApi.Controllers
{
    public class DeviceController : BaseApiController
    {
        public Device Get(string ip, string mac)
        {
            if (string.IsNullOrEmpty(ip)) throw new ArgumentNullException("ip");
            if (string.IsNullOrEmpty(mac)) throw new ArgumentNullException("mac");

            return Context.Devices.FirstOrDefault(x => x.IpAddress == ip && x.MacAddress == mac);
        }
    }
}
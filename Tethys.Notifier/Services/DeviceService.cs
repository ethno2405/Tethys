using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using Tethys.Notifier.Infrastructure;
using Tethys.Notifier.Models;

namespace Tethys.Notifier.Services
{
    public class DeviceService
    {
        public async Task<Device> Get(string ipAddress, string macAddress)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/device/get?ip=", ipAddress, "&mac=", macAddress));

                return Json.Decode<Device>(json);
            }
        }
    }
}
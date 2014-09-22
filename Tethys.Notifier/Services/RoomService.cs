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
    public class RoomService
    {
        public async Task<IList<Room>> Get()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/room/get"));

                return Json.Decode<IList<Room>>(json);
            }
        }

        public async Task<IList<Room>> Get(string departmentName)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/room/get", "department=", departmentName));

                return Json.Decode<IList<Room>>(json);
            }
        }

        public async Task<Room> Get(string departmentName, string roomName)
        {
            using (var httpClient = new HttpClient())
            {
                var getParameters = string.Format("departmentName={0}&roomName={1}", departmentName, roomName);
                var json = await httpClient.GetStringAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/room/get?", getParameters));

                return Json.Decode<Room>(json);
            }
        }
    }
}
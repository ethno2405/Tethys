using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using Tethys.Notifier.Infrastructure;
using Tethys.Notifier.Models.Calls;

namespace Tethys.Notifier.Services
{
    public class CallTypeService
    {
        public async Task<IList<CallType>> Get()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/calltype/get"));

                return Json.Decode<IList<CallType>>(json);
            }
        }

        public async Task<CallType> Get(string callType)
        {
            if (string.IsNullOrEmpty(callType)) throw new ArgumentNullException("callType");

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/calltype/get?calltype=", callType));

                return Json.Decode<CallType>(json);
            }
        }
    }
}
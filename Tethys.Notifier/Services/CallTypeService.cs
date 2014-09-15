using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using Tethys.Notifier.Models.Calls;

namespace Tethys.Notifier.Services
{
    public class CallTypeService
    {
        private string baseUrl = "http://localhost:5050/api";

        public async Task<IList<CallType>> Get()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Concat(baseUrl, "/calltype/get"));

                return Json.Decode<IList<CallType>>(json);
            }
        }
    }
}
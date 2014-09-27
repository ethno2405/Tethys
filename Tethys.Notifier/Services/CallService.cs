using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using Tethys.Notifier.Infrastructure;
using Tethys.Notifier.Models.Calls;

namespace Tethys.Notifier.Services
{
    public class CallService
    {
        public async Task Notity(Call call)
        {
            using (var httpClient = new HttpClient())
            {
                var json = Json.Encode(call);
                var content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                await httpClient.PostAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/call/notify"), content);
            }
        }
    }
}
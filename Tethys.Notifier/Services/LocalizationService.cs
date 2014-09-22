using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using Tethys.Notifier.Infrastructure;
using Tethys.Notifier.Models;

namespace Tethys.Notifier.Services
{
    public class LocalizationService
    {
        public async Task<HttpResponseMessage> Localize(Device device)
        {
            using (var httpClient = new HttpClient())
            {
                var json = Json.Encode(device);
                var content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return await httpClient.PostAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/localization/localize"), content);
            }
        }
    }
}
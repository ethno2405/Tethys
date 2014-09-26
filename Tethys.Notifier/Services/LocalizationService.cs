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
using Tethys.Notifier.Models.Requests;
using Tethys.Notifier.Models.Responses;

namespace Tethys.Notifier.Services
{
    public class LocalizationService
    {
        public async Task<LocalizationResponse> Localize(Device device)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new LocalizationRequest(device);
                var json = Json.Encode(request);
                var content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var httpResponse = await httpClient.PostAsync(string.Concat(GlobalSettings.Current.ObserverWebApiBaseUrl, "/localization/localize"), content);

                return Json.Decode<LocalizationResponse>(await httpResponse.Content.ReadAsStringAsync());
            }
        }
    }
}
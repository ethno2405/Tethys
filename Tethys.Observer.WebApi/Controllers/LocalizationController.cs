using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tethys.Observer.Domain.Entities;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.WebApi.Models.Responses;

namespace Tethys.Observer.WebApi.Controllers
{
    public class LocalizationController : BaseApiController
    {
        public LocalizationResponse Localize(Device device)
        {
            try
            {
                var deviceService = new DeviceService(Context);
                var message = deviceService.Localize(device);

                return new LocalizationResponse(message);
            }
            catch (Exception ex)
            {
                return new LocalizationResponse(ex);
            }
        }
    }
}
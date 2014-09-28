using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tethys.Observer.Domain.Entities;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.Models.WebApi.Requests;

namespace Tethys.Observer.Controllers.WebApi
{
    public class LocalizationController : BaseApiController
    {
        [HttpPost]
        public LocalizationResponse Localize(LocalizationRequest request)
        {
            try
            {
                var deviceService = new DeviceService(Context);
                var device = new Device
                {
                    Name = request.Name,
                    IpAddress = request.IpAddress,
                    MacAddress = request.MacAddress,
                    IsLocalized = request.IsLocalized,
                    Room = new Room
                    {
                        Department = new Department
                        {
                            Name = request.Department
                        },
                        Name = request.Room
                    },
                    Location = new Location
                    {
                        Name = request.Location
                    }
                };

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
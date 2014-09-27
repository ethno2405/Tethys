using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tethys.Observer.Domain.Entities;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.WebApi.Models.Requests;

namespace Tethys.Observer.WebApi.Controllers
{
    public class CallController : BaseApiController
    {
        [HttpPost]
        public void Notify(CallRequest request)
        {
            var callService = new CallService(Context);
            callService.Notify(request.CreatedOn, request.MacAddress, request.IpAddress, request.CallType);
        }
    }
}
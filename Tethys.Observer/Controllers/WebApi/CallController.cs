using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Tethys.Observer.Domain.Entities;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.Hubs;
using Tethys.Observer.Models;
using Tethys.Observer.Models.WebApi.Requests;

namespace Tethys.Observer.Controllers.WebApi
{
    public class CallController : BaseApiController
    {
        [HttpPost]
        public void Notify(CallRequest request)
        {
            var callService = new CallService(Context);
            var call = callService.Notify(request.CreatedOn, request.MacAddress, request.IpAddress, request.CallType);

            GlobalHost.ConnectionManager.GetHubContext<CallHub>().Clients.All.callRecieved(new CallNotification(call));
        }
    }
}
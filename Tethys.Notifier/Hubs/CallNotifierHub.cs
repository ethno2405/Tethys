using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Tethys.Notifier.Infrastructure;
using Tethys.Notifier.Models.Calls;
using Tethys.Notifier.Services;

namespace Tethys.Notifier.Hubs
{
    public class CallNotifierHub : Hub
    {
        public void Notify(string callType)
        {
            var ip = Context.Request.Environment["server.RemoteIpAddress"].ToString();
            var call = new Call
            {
                CreatedOn = DateTime.Now,
                CallType = callType,
                MacAddress = NativeMethods.GetMacAddress(ip),
                IpAddress = ip
            };

            var callService = new CallService();
            Task.Run(async () => await callService.Notity(call));

            Clients.Caller.callRecieved(callType);
        }
    }
}
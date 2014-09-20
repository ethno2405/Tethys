using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Tethys.Notifier.Hubs
{
    public class CallNotifierHub : Hub
    {
        public void Notify(string callType)
        {
            Clients.Caller.callRecieved(callType);
        }
    }
}
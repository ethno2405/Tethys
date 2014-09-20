using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Tethys.Notifier.Hubs
{
    public class LocalizationHub : Hub
    {
        public void Localize(string department, string room, string location)
        {
        }
    }
}
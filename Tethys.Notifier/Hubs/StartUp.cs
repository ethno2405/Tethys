using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace Tethys.Notifier.Hubs
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
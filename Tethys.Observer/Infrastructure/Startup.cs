using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace Tethys.Observer.Infrastructure
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
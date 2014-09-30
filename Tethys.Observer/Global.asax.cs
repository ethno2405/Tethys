using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.Hubs;
using Tethys.Observer.Infrastructure;

namespace Tethys.Observer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
        }
    }
}
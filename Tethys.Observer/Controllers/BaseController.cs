using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tethys.Observer.Domain;
using Tethys.Observer.Domain.DataAccess;

namespace Tethys.Observer.Controllers
{
    public abstract class BaseController : Controller
    {
        internal TethysContext Context { get; set; }
    }
}
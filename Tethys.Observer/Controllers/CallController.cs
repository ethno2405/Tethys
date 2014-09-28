using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tethys.Observer.Infrastructure;
using Tethys.Observer.ViewModels.Call;

namespace Tethys.Observer.Controllers
{
    [RequireAuthorization]
    public class CallController : BaseController
    {
        public ActionResult GetCalls()
        {
            var model = new CallsViewModel
            {
                Calls = Context.Calls.OrderByDescending(x => x.CreatedOn).ToList()
            };

            return View(model);
        }

        public ActionResult List()
        {
            return View();
        }
    }
}
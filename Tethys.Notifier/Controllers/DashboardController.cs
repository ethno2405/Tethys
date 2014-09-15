using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tethys.Notifier.Services;
using Tethys.Notifier.ViewModels.Dashboard;

namespace Tethys.Notifier.Controllers
{
    public class DashboardController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var callTypeService = new CallTypeService();
            var calltypes = await callTypeService.Get();
            var model = new IndexViewModel
            {
                CallTypes = calltypes
            };

            return View(model);
        }

        public ActionResult Index(IndexViewModel model)
        {
            return View(model);
        }
    }
}
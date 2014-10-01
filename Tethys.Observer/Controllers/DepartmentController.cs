using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.Infrastructure;
using Tethys.Observer.ViewModels.Department;

namespace Tethys.Observer.Controllers
{
    [RequireAuthorization]
    public class DepartmentController : BaseController
    {
        [HttpPost]
        public ActionResult Create(DepartmentsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("List", model);
            }

            var departmentService = new DepartmentService(Context);
            departmentService.Create(model.NewDepartmentName);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var department = Context.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                return HttpNotFound();
            }

            if (department.Rooms.Any())
            {
                return HttpNotFound();
            }

            var departmentService = new DepartmentService(Context);
            departmentService.Delete(department);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var model = new DepartmentsViewModel
            {
                Departments = Context.Departments.OrderBy(x => x.Name).ToList()
            };

            return View(model);
        }
    }
}
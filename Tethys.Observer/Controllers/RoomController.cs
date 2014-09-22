using System;
using System.Linq;
using System.Web.Mvc;
using Tethys.Observer.Domain.Entities;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.Infrastructure;
using Tethys.Observer.ViewModels.Room;

namespace Tethys.Observer.Controllers
{
    [RequireAuthorization]
    public class RoomController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateRoomViewModel
            {
                Departments = Context.Departments
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateRoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var roomService = new RoomService(Context);

            roomService.AssignRoomToDepartment(model.DepartmentName, model.Name);

            return RedirectToAction("Create");
        }

        public ActionResult List()
        {
            var model = new RoomsListViewModel
            {
                Rooms = Context.Rooms.ToList()
            };

            return View(model);
        }
    }
}
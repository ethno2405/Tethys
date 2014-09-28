using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Tethys.Observer.Domain.Entities;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.Hubs;
using Tethys.Observer.Infrastructure;
using Tethys.Observer.ViewModels.Room;

namespace Tethys.Observer.Controllers
{
    [RequireAuthorization]
    public class RoomController : BaseController
    {
        [HttpPost]
        public ActionResult Create(RoomsListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Rooms = (Session["Rooms"] as IList<Room>) ?? new List<Room>();
                model.DepartmentsNames = (Session["DepartmentsNames"] as IList<string>) ?? new List<string>();

                return View("List", model);
            }

            var roomService = new RoomService(Context);

            roomService.AssignRoomToDepartment(model.NewRoomDepartment, model.NewRoomName);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var model = new RoomsListViewModel
            {
                Rooms = Context.Rooms.ToList(),
                DepartmentsNames = Context.Departments.Select(x => x.Name).ToList()
            };

            Session["Rooms"] = model.Rooms;
            Session["DepartmentsNames"] = model.DepartmentsNames;

            return View(model);
        }
    }
}
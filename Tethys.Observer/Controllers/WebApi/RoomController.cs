using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Controllers.WebApi
{
    public class RoomController : BaseApiController
    {
        public IEnumerable<Room> Get()
        {
            return Context.Rooms;
        }

        public IEnumerable<Room> Get(string department)
        {
            return Context.Rooms.Where(x => x.Department.Name == department);
        }

        public Room Get(string departmentName, string roomName)
        {
            return Context.Rooms.FirstOrDefault(x => x.Name == roomName && x.Department.Name == departmentName);
        }
    }
}
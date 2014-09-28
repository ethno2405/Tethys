using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Controllers.WebApi
{
    public class LocationController : BaseApiController
    {
        public IEnumerable<Location> Get(string department, string room)
        {
            var existingRoom = Context.Rooms.FirstOrDefault(x => x.Department.Name == department && x.Name == room);

            return existingRoom == null ? new Location[0] : existingRoom.Locations;
        }
    }
}
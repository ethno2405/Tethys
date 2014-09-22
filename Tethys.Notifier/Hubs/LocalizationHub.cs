using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Tethys.Notifier.Models;
using Tethys.Notifier.Services;

namespace Tethys.Notifier.Hubs
{
    public class LocalizationHub : Hub
    {
        public void GetLocations(string room, string department)
        {
            var roomService = new RoomService();
            var existingRoom = Task.Run(async () => await roomService.Get(department, room)).Result;

            Clients.Caller.locationsRecieved(existingRoom.Locations);
        }

        public void GetRooms(string department)
        {
            if (string.IsNullOrEmpty(department))
            {
                Clients.Caller.roomsRecieved(new object[0]);
            }

            var roomService = new RoomService();
            var rooms = Task.Run(async () => await roomService.Get(department)).Result;

            Clients.Caller.roomsRecieved(rooms);
        }

        public void Localize(string department, string room, string location)
        {
        }
    }
}
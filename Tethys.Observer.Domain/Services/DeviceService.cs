using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Domain.Services
{
    public class DeviceService : BaseService
    {
        public DeviceService(TethysContext context)
            : base(context)
        {
        }

        public void AssignDeviceToRoom(Device device, string roomName)
        {
            if (device == null) throw new ArgumentNullException("device");
            if (string.IsNullOrEmpty(roomName)) throw new ArgumentNullException("roomName");

            var room = Context.Rooms.FirstOrDefault(x => x.Name == roomName);
            if (room == null)
            {
                throw new InvalidOperationException(string.Format("Room {0} was not found", roomName));
            }

            var roomService = new RoomService(Context);
            roomService.AssignDevice(room, device);
        }
    }
}
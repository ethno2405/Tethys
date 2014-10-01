using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Domain.Services
{
    public class RoomService : BaseService
    {
        public RoomService(TethysContext context)
            : base(context)
        {
        }

        public void AssignDevice(Room room, Device device)
        {
            if (room == null) throw new ArgumentNullException("room");
            if (device == null) throw new ArgumentNullException("device");

            var existingRoom = Context.Rooms.FirstOrDefault(x => x.Id == room.Id);
            if (existingRoom == null)
            {
                throw new InvalidOperationException(string.Format("Room with id {0} does not exist", room.Id));
            }

            if (device.Location == null)
            {
                throw new ArgumentException("Device is not assigned to a location");
            }

            if (!existingRoom.Locations.Any(x => x.Name == device.Location.Name))
            {
                throw new InvalidOperationException(string.Format("Location {0} is not available in room {1}", device.Location.Name, room.Name));
            }

            existingRoom.Devices.Add(device);
            Context.SaveChanges();
        }

        public void AssignRoomToDepartment(Department department, Room room)
        {
            if (department == null) throw new ArgumentNullException("department");
            if (room == null) throw new ArgumentNullException("room");

            var departmentService = new DepartmentService(Context);
            departmentService.AssignRoom(department, room);
        }

        public void AssignRoomToDepartment(string departmentName, Room room)
        {
            if (string.IsNullOrEmpty(departmentName)) throw new ArgumentNullException("department");
            if (room == null) throw new ArgumentNullException("room");

            var departmentService = new DepartmentService(Context);

            departmentService.AssignRoom(departmentName, room);
        }

        public void AssignRoomToDepartment(string departmentName, string roomName)
        {
            if (string.IsNullOrEmpty(departmentName)) throw new ArgumentNullException("department");
            if (string.IsNullOrEmpty(roomName)) throw new ArgumentNullException("roomName");

            var departmentService = new DepartmentService(Context);

            departmentService.AssignRoom(departmentName, roomName);
        }

        public void Delete(Room room)
        {
            if (room == null) throw new ArgumentNullException("room");

            if (Context.Entry(room).State == EntityState.Detached)
            {
                room = Context.Rooms.FirstOrDefault(x => x.Id == room.Id);
            }

            Context.Rooms.Remove(room);
            Context.SaveChanges();
        }
    }
}
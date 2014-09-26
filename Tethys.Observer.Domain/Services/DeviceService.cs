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

        public Device Create(string name, string ipAddress, string macAddress, bool isLocalized)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(ipAddress)) throw new ArgumentNullException("ipAddress");
            if (string.IsNullOrEmpty(macAddress)) throw new ArgumentNullException("macAddress");

            return new Device
            {
                Id = Guid.NewGuid(),
                Name = name,
                IpAddress = ipAddress,
                MacAddress = macAddress,
                IsLocalized = isLocalized
            };
        }

        public string Localize(Device device)
        {
            if (device == null) throw new ArgumentNullException("device");
            if (device.Room == null) return "Unknown device room";
            if (device.Room.Department == null) return "Unknown department";
            if (device.Location == null) return "Unknown device location";

            var department = Context.Departments.FirstOrDefault(x => x.Name == device.Room.Department.Name);
            if (department == null)
            {
                return string.Format("Department {0} does not exist.", device.Room.Department.Name);
            }

            var room = department.Rooms.FirstOrDefault(x => x.Name == device.Room.Name);
            if (room == null)
            {
                return string.Format("Room {0} was not found in department {1}", device.Room.Name, department.Name);
            }

            var location = room.Locations.FirstOrDefault(x => x.Name == device.Location.Name);
            if (location == null)
            {
                return string.Format("Location {0} was not found in room {1}", device.Location.Name, room.Name);
            }

            var existingDevice = Context.Devices.FirstOrDefault(x => x.IpAddress == device.IpAddress && x.MacAddress == device.MacAddress);
            if (existingDevice != null)
            {
                existingDevice.Name = device.Name;
                existingDevice.IsLocalized = true;
                existingDevice.Location = location;
                existingDevice.Room = room;

                Context.SaveChanges();

                return string.Format("Device {0} was successfully localized in department {1}, room {2}, location {3}", device.Name, department.Name, room.Name, location.Name);
            }

            var newDevice = Create(device.Name, device.IpAddress, device.MacAddress, true);

            newDevice.Location = location;
            room.Devices.Add(newDevice);

            Context.SaveChanges();

            return string.Format("Device {0} was successfully localized in department {1}, room {2}, location {3}", device.Name, department.Name, room.Name, location.Name);
        }

        public void Unlocalize(Device device)
        {
            if (device == null) throw new ArgumentNullException();

            device.Location = null;
            device.Room = null;
            device.IsLocalized = false;

            Context.SaveChanges();
        }
    }
}
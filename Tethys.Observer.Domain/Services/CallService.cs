using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Domain.Services
{
    public class CallService : BaseService
    {
        public CallService(TethysContext context)
            : base(context)
        {
        }

        public void Notify(DateTime createdOn, string macAddress, string ipAddress, string callType)
        {
            if (createdOn == DateTime.MinValue) throw new ArgumentOutOfRangeException("createdOn");
            if (string.IsNullOrEmpty(macAddress)) throw new ArgumentNullException("macAddress");
            if (string.IsNullOrEmpty(ipAddress)) throw new ArgumentNullException("ipAddress");
            if (string.IsNullOrEmpty(callType)) throw new ArgumentNullException("callType");

            var device = Context.Devices.FirstOrDefault(x => x.IpAddress == ipAddress && x.MacAddress == macAddress);
            if (device == null)
            {
                throw new InvalidOperationException(string.Format("Device with IP address {0} and MAC address {1} was not found.", ipAddress, macAddress));
            }

            if (!device.IsLocalized)
            {
                throw new InvalidOperationException(string.Format("Device {0} with IP address {1} and MAC address {2} is not localized.", device.Name, ipAddress, macAddress));
            }

            var existingCallType = Context.CallTypes.FirstOrDefault(x => x.Name == callType);
            if (existingCallType == null)
            {
                throw new NotSupportedException(string.Format("Unrecognized call type {0}", callType));
            }

            var call = new Call
            {
                Id = Guid.NewGuid(),
                CreatedOn = createdOn,
                IpAddress = device.IpAddress,
                MacAddress = device.MacAddress,
                Department = device.Room.Department.Name,
                Device = device.Name,
                Location = device.Location.Name,
                Room = device.Room.Name,
                Type = existingCallType
            };

            Context.Calls.Add(call);
            Context.SaveChanges();
        }
    }
}
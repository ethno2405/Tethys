using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Models
{
    public class CallNotification
    {
        private readonly Call call;

        public CallNotification(Call call)
        {
            if (call == null) throw new ArgumentNullException("call");

            this.call = call;
        }

        public string Message
        {
            get
            {
                return string.Format("{0} call: Room {1}, {2}; Department {3}", call.Type.Name, call.Room, call.Location, call.Department);
            }
        }
    }
}
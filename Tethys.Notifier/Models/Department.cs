using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tethys.Notifier.Models
{
    public class Department
    {
        public string Name { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
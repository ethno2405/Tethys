using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tethys.Observer.Domain.Entities
{
    public class Room
    {
        [Required]
        public virtual Department Department { get; set; }

        public virtual ICollection<Device> Devices { get; set; }

        public Guid Id { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
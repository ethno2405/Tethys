using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Tethys.Observer.Domain.Entities
{
    public class Device
    {
        public Guid Id { get; set; }

        public string IpAddress { get; set; }

        [Required]
        public bool IsLocalized { get; set; }

        public virtual Location Location { get; set; }

        public string MacAddress { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Room Room { get; set; }
    }
}
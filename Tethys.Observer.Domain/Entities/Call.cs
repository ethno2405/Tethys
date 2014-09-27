using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tethys.Observer.Domain.Entities
{
    public class Call
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Device { get; set; }

        public Guid Id { get; set; }

        public string IpAddress { get; set; }

        [Required]
        public string Location { get; set; }

        public string MacAddress { get; set; }

        [Required]
        public string Room { get; set; }

        [Required]
        public virtual CallType Type { get; set; }
    }
}
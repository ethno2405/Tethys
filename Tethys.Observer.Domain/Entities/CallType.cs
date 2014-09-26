using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tethys.Observer.Domain.Entities
{
    public class CallType
    {
        [MaxLength(7)]
        public string Color { get; set; }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
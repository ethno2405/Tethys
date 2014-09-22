using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tethys.Observer.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Index("IX_Location_Name")]
        public string Name { get; set; }
    }
}
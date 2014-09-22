using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tethys.Observer.Domain.Entities
{
    public class Room
    {
        public virtual Department Department { get; set; }

        [Column("Department_Id")]
        [Index("IX_Unique_Department_Room", Order = 0, IsUnique = true)]
        public Guid DepartmentId { get; set; }

        public virtual ICollection<Device> Devices { get; set; }

        public Guid Id { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        [Required]
        [MaxLength(20)]
        [Index("IX_Unique_Department_Room", Order = 1, IsUnique = true)]
        public string Name { get; set; }
    }
}
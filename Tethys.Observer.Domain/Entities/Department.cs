using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tethys.Observer.Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Index("IX_DeparatmentName_Unique", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
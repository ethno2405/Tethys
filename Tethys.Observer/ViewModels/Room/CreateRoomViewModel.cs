using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tethys.Observer.ViewModels.Room
{
    public class CreateRoomViewModel
    {
        [DisplayName("Department")]
        public string DepartmentName { get; set; }

        public IEnumerable<Observer.Domain.Entities.Department> Departments { get; set; }

        [MaxLength(20)]
        [DisplayName("Room name")]
        [Required(ErrorMessage = "Please specify a room name")]
        public string Name { get; set; }
    }
}
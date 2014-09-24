using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tethys.Observer.ViewModels.Room
{
    public class RoomsListViewModel
    {
        public IList<string> DepartmentsNames { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Please select a department")]
        public string NewRoomDepartment { get; set; }

        [DisplayName("New room")]
        [Required(ErrorMessage = "Please specify a room name")]
        public string NewRoomName { get; set; }

        public IList<Tethys.Observer.Domain.Entities.Room> Rooms { get; set; }
    }
}
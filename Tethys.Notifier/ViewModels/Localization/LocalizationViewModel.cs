using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tethys.Notifier.Models;

namespace Tethys.Notifier.ViewModels.Localization
{
    public class LocalizationViewModel
    {
        public IEnumerable<Department> Departments { get; set; }

        public Device Device { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

        public string SelectedLocationName { get; set; }

        [DisplayName("Room")]
        [Required(ErrorMessage = "Please select a room")]
        public string SelectedRoomName { get; set; }
    }
}
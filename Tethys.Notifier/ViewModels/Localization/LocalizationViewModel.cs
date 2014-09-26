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

        [DisplayName("Device")]
        [Required(ErrorMessage = "Please select a device name")]
        public string DeviceName { get; set; }

        [DisplayName("IP address")]
        public string IpAddress { get; set; }

        [DisplayName("MAC address")]
        public string MacAddress { get; set; }

        public IEnumerable<Room> Rooms { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "Please select a department")]
        public string SelectedDepartmentName { get; set; }

        [DisplayName("Location")]
        [Required(ErrorMessage = "Please select a room location")]
        public string SelectedLocationName { get; set; }

        [DisplayName("Room")]
        [Required(ErrorMessage = "Please select a room")]
        public string SelectedRoomName { get; set; }
    }
}
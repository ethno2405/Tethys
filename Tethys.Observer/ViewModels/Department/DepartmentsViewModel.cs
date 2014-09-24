using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tethys.Observer.ViewModels.Department
{
    public class DepartmentsViewModel
    {
        public IEnumerable<Observer.Domain.Entities.Department> Departments { get; set; }

        [MaxLength(20)]
        [DisplayName("Department")]
        [Required(ErrorMessage = "Please specify a department name")]
        public string NewDepartmentName { get; set; }
    }
}
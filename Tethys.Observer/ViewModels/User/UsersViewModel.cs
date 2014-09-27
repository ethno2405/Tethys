using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.ViewModels.User
{
    public class UsersViewModel
    {
        [Required]
        [DisplayName("Confirm password")]
        public string NewUserConfirmPassword { get; set; }

        [Required]
        [DisplayName("First name")]
        public string NewUserFirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string NewUserLastName { get; set; }

        [Required]
        [DisplayName("Username")]
        public string NewUserLogin { get; set; }

        [Required]
        [DisplayName("Password")]
        public string NewUserPassword { get; set; }

        [Required]
        [DisplayName("Role")]
        public string NewUserRole { get; set; }

        public IList<Role> Roles { get; set; }

        public IList<Domain.Entities.User> Users { get; set; }
    }
}
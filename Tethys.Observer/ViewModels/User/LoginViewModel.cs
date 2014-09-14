using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tethys.Observer.ViewModels.User
{
    public class LoginViewModel
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Please provide a username")]
        public string Login { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Please provide a password")]
        public string Password { get; set; }
    }
}
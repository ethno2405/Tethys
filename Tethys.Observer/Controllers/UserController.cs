using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tethys.Observer.Infrastructure;
using Tethys.Observer.ViewModels.User;

namespace Tethys.Observer.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (SecurityManager.Current.LoggedUser != null)
            {
                return RedirectToAction("List", "Room");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!SecurityManager.Current.TryLogin(model.Login, model.Password, Context))
            {
                ModelState.AddModelError("Username", "Invalid username or password.");

                return View(model);
            }

            return RedirectToAction("List", "Room");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            SecurityManager.Current.Logout();

            return RedirectToAction("Login");
        }
    }
}
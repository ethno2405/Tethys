using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tethys.Observer.Domain.Services;
using Tethys.Observer.Infrastructure;
using Tethys.Observer.ViewModels.User;

namespace Tethys.Observer.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var userService = new UserService(Context);
            userService.Delete(id);

            return RedirectToAction("List");
        }

        [HttpGet]
        [RequireAuthorization("System Administrator", "Technical Administrator")]
        public ActionResult List()
        {
            var model = new UsersViewModel
            {
                Users = Context.Users.ToList(),
                Roles = Context.Roles.ToList()
            };

            return View(model);
        }

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

            return RedirectToAction("List", "Call");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            SecurityManager.Current.Logout();

            return RedirectToAction("Login");
        }

        [HttpPost]
        [RequireAuthorization("System Administrator", "Technical Administrator")]
        public ActionResult Register(UsersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Users = Context.Users.ToList();
                model.Roles = Context.Roles.ToList();

                return View("List", model);
            }

            if (Context.Users.Any(x => x.Login == model.NewUserLogin))
            {
                ModelState.AddModelError("NewUserLogin", string.Format("A user with username {0} already exists", model.NewUserLogin));
                model.Users = Context.Users.ToList();
                model.Roles = Context.Roles.ToList();

                return View("List", model);
            }

            if (model.NewUserPassword != model.NewUserConfirmPassword)
            {
                ModelState.AddModelError("NewUserConfirmPassword", "Passwords do not match");
                model.Users = Context.Users.ToList();
                model.Roles = Context.Roles.ToList();

                return View("List", model);
            }

            var userService = new UserService(Context);
            userService.Register(model.NewUserLogin, model.NewUserPassword, model.NewUserFirstName, model.NewUserLastName, model.NewUserRole);

            return RedirectToAction("List");
        }
    }
}
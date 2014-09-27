using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tethys.Observer.ViewModels.Modal;

namespace Tethys.Observer.Controllers
{
    public class ModalController : BaseController
    {
        public ActionResult Popup(string title, string message, string confirmUrl)
        {
            var model = new PopupViewModel
            {
                Title = title,
                Message = message,
                ConfirmUrl = confirmUrl
            };

            return View(model);
        }
    }
}
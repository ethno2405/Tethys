using System.Linq;
using System.Web.Mvc;
using Tethys.Observer.Infrastructure;
using Tethys.Observer.ViewModels.Room;

namespace Tethys.Observer.Controllers
{
    [RequireAuthorization]
    public class RoomController : BaseController
    {
        public ActionResult List()
        {
            var model = new RoomsListViewModel
            {
                Rooms = Context.Rooms.ToList()
            };

            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Observer.ViewModels.Room
{
    public class RoomsListViewModel
    {
        public IList<Tethys.Observer.Domain.Entities.Room> Rooms { get; set; }
    }
}
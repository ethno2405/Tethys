using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Observer.ViewModels.Device
{
    public class DevicesViewModel
    {
        public IList<Domain.Entities.Device> Devices { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Observer.ViewModels.Call
{
    public class CallsViewModel
    {
        public IList<Domain.Entities.Call> Calls { get; set; }
    }
}
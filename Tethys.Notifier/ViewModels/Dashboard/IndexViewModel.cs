using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tethys.Notifier.Models.Calls;

namespace Tethys.Notifier.ViewModels.Dashboard
{
    public class IndexViewModel
    {
        public IList<CallType> CallTypes { get; set; }

        public bool IsLocalized { get; set; }

        public string Message { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Notifier.Models.Calls
{
    public class Call
    {
        public DateTime CreatedOn { get; set; }

        public CallType Type { get; set; }
    }
}
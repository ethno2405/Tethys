﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Notifier.Models.Calls
{
    public class Call
    {
        public string CallType { get; set; }

        public DateTime CreatedOn { get; set; }

        public string IpAddress { get; set; }

        public string MacAddress { get; set; }
    }
}
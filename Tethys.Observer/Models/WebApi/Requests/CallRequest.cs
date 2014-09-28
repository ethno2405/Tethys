﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Models.WebApi.Requests
{
    public class CallRequest
    {
        public string CallType { get; set; }

        public DateTime CreatedOn { get; set; }

        public string IpAddress { get; set; }

        public string MacAddress { get; set; }
    }
}
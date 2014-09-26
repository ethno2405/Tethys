using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Notifier.Models.Responses
{
    public class LocalizationResponse
    {
        public Exception Error { get; set; }

        public bool HasError { get; set; }

        public string Message { get; set; }
    }
}
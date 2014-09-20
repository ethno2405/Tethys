using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tethys.Observer.WebApi.Models.Responses
{
    public class LocalizationResponse
    {
        private string message;

        public LocalizationResponse(string message)
        {
            this.message = message;
        }

        public LocalizationResponse(Exception error)
        {
            Error = error;
        }

        public Exception Error { get; set; }

        public bool HasError
        {
            get
            {
                return Error != null;
            }
        }

        public string Message
        {
            get
            {
                if (HasError)
                {
                    return Error.Message;
                }

                return message ?? string.Empty;
            }
            set
            {
                message = value;
            }
        }
    }
}
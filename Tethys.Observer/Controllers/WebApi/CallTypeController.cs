using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Controllers.WebApi
{
    public class CallTypeController : BaseApiController
    {
        public IQueryable<CallType> Get()
        {
            return Context.CallTypes;
        }

        public CallType Get(string callType)
        {
            return Context.CallTypes.FirstOrDefault(x => x.Name == callType);
        }
    }
}
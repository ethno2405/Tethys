using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Tethys.Observer.Domain.DataAccess;

namespace Tethys.Observer.WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private TethysContext context;

        protected TethysContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new TethysContext();
                }

                return context;
            }
        }
    }
}
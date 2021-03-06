﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Tethys.Observer.Domain.DataAccess;

namespace Tethys.Observer.Controllers.WebApi
{
    public abstract class BaseApiController : ApiController
    {
        private static readonly object mutex = new object();
        private TethysContext context;

        protected TethysContext Context
        {
            get
            {
                if (context == null)
                {
                    lock (mutex)
                    {
                        if (context == null)
                        {
                            context = new TethysContext();
                        }
                    }
                }

                return context;
            }
        }
    }
}
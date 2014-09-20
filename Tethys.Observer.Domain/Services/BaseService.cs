using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tethys.Observer.Domain.DataAccess;

namespace Tethys.Observer.Domain.Services
{
    public abstract class BaseService
    {
        private readonly TethysContext context;

        protected BaseService()
            : this(new TethysContext())
        {
        }

        protected BaseService(TethysContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.context = context;
        }

        public TethysContext Context
        {
            get
            {
                return context;
            }
        }
    }
}
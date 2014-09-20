using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Domain.Services
{
    public class LocationService : BaseService
    {
        public LocationService(TethysContext context)
            : base(context)
        {
        }

        public void Create(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            if (Context.Locations.Any(x => x.Name == name))
            {
                throw new InvalidOperationException(string.Format("A location named {0} already exists.", name));
            }

            var location = new Location
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            Context.Locations.Add(location);
            Context.SaveChanges();
        }
    }
}
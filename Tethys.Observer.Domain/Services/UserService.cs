using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tethys.Observer.Domain.Common;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Domain.Services
{
    public class UserService : BaseService
    {
        public UserService(TethysContext context)
            : base(context)
        {
        }

        public void Delete(Guid id)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new ArgumentException(string.Format("User with id {0} was not found", id));
            }

            Context.Users.Remove(user);
            Context.SaveChanges();
        }

        public void Register(string login, string password, string firstName, string lastName, string role)
        {
            if (string.IsNullOrEmpty(login)) throw new ArgumentNullException("login");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentNullException("firstName");
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentNullException("lastName");
            if (string.IsNullOrEmpty(role)) throw new ArgumentNullException("role");

            var existingRole = Context.Roles.FirstOrDefault(x => x.Name == role);
            if (existingRole == null)
            {
                throw new ArgumentException(string.Format("Role {0} does not exist", role));
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = password.GetSHA512(),
                FirstName = firstName,
                LastName = lastName,
                Role = existingRole
            };

            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
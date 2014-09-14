using System;
using System.Data.Entity.Migrations;
using System.Security.Cryptography;
using System.Text;
using Tethys.Observer.Domain.Common;
using Tethys.Observer.Domain.DataAccess;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TethysContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Tethys.Observer.Domain.DataAccess.TethysContext";
        }

        protected override void Seed(TethysContext context)
        {
            context.Users.Add(new User
            {
                FirstName = "System",
                LastName = "Administrator",
                Login = "sa",
                Password = "Password.123".GetSHA512(),
                Role = "System Administrator"
            });
        }
    }
}
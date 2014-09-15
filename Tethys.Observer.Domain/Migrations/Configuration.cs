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
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Tethys.Observer.Domain.DataAccess.TethysContext";
        }

        protected override void Seed(TethysContext context)
        {
            context.Users.AddOrUpdate(new User
            {
                FirstName = "System",
                LastName = "Administrator",
                Login = "sa",
                Password = "Password.123".GetSHA512(),
                Role = "System Administrator"
            });

            context.CallTypes.AddOrUpdate(
                new CallType
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Emergency",
                },
                new CallType
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Assistance",
                },
                new CallType
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Sanitary",
                },
                new CallType
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Name = "Sanitary Assistance",
                },
                new CallType
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Name = "Doctor",
                },
                new CallType
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    Name = "Presence",
                });
        }
    }
}
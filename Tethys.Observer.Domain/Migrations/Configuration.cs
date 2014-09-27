using System;
using System.Data.Entity.Migrations;
using System.Linq;
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
            var systemAdministrator = new Role
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "System Administrator"
            };

            context.Roles.AddOrUpdate(
            systemAdministrator,
            new Role
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Technical Administrator"
            },
            new Role
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Head nurse"
            },
            new Role
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Nurse"
            },
            new Role
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Name = "Sanitarian"
            },
            new Role
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Name = "Doctor"
            });

            context.Users.AddOrUpdate(
            new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                FirstName = "System",
                LastName = "Administrator",
                Login = "sa",
                Password = "Password.123".GetSHA512(),
                Role = systemAdministrator
            });

            context.CallTypes.AddOrUpdate(
            new CallType
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Emergency",
                Color = "#cc0000"
            },
            new CallType
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Assistance",
                Color = "#ffa500"
            },
            new CallType
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Sanitary",
                Color = "#5370ae"
            },
            new CallType
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Sanitary Assistance",
                Color = "#ffe800"
            },
            new CallType
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Name = "Doctor",
                Color = "#a7d7f0"
            },
            new CallType
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Name = "Presence",
                Color = "#2a8300"
            });

            context.Locations.AddOrUpdate(
            new Location
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "BED1"
            },
            new Location
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "BED2"
            },
            new Location
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "BED3"
            },
            new Location
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "BED4"
            },
            new Location
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                Name = "BED5"
            },
            new Location
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Name = "Next to the door"
            });
        }
    }
}
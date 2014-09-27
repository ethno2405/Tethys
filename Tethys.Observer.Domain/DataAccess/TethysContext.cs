using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tethys.Observer.Domain.Entities;

namespace Tethys.Observer.Domain.DataAccess
{
    public class TethysContext : DbContext
    {
        public TethysContext()
            : this("Tethys")
        {
        }

        public TethysContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Call> Calls { get; set; }

        public DbSet<CallType> CallTypes { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Room>().HasMany(r => r.Locations).WithMany();
        }
    }
}
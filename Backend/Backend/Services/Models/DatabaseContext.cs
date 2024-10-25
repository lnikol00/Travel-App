using Backend.Services.CarsService.Models;
using Backend.Services.EmployeeService.Models;
using Backend.Services.TravelOrdersService.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<TravelOrderDB> TravelOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>(c =>
            {
                c.HasKey(c => new { c.Id });
                c.Property(c => c.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(e => new { e.Id });
                e.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<TravelOrderDB>(to =>
            {
                to.HasKey(to => new { to.Id });
                to.Property(to => to.Id).ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace WebApp.WebUI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<TravelOrder> TravelOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(" Data Source=DESKTOP-0VO0VSO\\SQLEXPRESS;Database=TravelDbMVC;TrustServerCertificate=True;Integrated Security=True");
        }


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
            modelBuilder.Entity<TravelOrder>(to =>
            {
                to.HasKey(to => new { to.Id });
                to.Property(to => to.Id).ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
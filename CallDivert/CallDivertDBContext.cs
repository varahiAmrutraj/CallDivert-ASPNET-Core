using Microsoft.EntityFrameworkCore;
using CallDivert.Models;
namespace CallDivert
{
    public class CallDivertDbContext : DbContext
    {
        public CallDivertDbContext(DbContextOptions<CallDivertDbContext> options) : base(options)
        {
        }

        // DbSet properties representing your entities
        // Example:
        // public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
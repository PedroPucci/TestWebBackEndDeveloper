using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Infrastracture.Connection
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Configuration.GetConnectionString("WebApiDatabase");
            ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public DbSet<AccountUser> AccountUser { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<Balance> Balance { get; set; }
    }
}
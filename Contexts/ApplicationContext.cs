using System.Net;
using APIApplication.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace APIApplication.Contexts
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _databaseName;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            _connectionString = "<your-connection-string>";
            _databaseName = "<your-database-name>";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("<your-container-name>");
            modelBuilder.Entity<Form>().ToContainer("<your-forms-container-name>");
            modelBuilder.Entity<Program>().ToContainer("<your-programs-container-name>");
            modelBuilder.Entity<Workflow>().ToContainer("<your-workflows-container-name>");
            modelBuilder.Entity<Preview>().ToContainer("<your-preview-container-name>");
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<AppProgram> AppPrograms { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Preview> Previews { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                _connectionString,
                _databaseName,
                options =>
                {
                    options.ConnectionMode(ConnectionMode.Gateway);
                    options.WebProxy(new WebProxy("<your-proxy-address>"));
                });

        }

    }
}

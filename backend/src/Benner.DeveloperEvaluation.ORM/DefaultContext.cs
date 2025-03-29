using Benner.DeveloperEvaluation.Domain.Entities;
using Benner.DeveloperEvaluation.ORM;
using Benner.DeveloperEvaluation.ORM.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Benner.DeveloperEvaluation.ORM
{
    public class DefaultContext: DbContext
    {
        public DbSet<ProgramaMicroonda> ProgramaMicroondas { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options): base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new ProgramaMicroondaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString,
            b => b.MigrationsAssembly("Benner.DeveloperEvaluation.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}

using DakaDiningBackend.Entities;
using DakaDiningBackend.Test.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Testcontainers.PostgreSql;

namespace DakaDiningBackend.Test;

public class ApiWebFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _database = new PostgreSqlBuilder()
        .WithDatabase("testDb")
        .WithUsername("testUser")
        .WithPassword("dont_care")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(logging => { logging.ClearProviders(); });

        // We configure our services for testing
        builder.ConfigureTestServices(services =>
        {
            // Remove any DbContext registrations
            services.RemoveAll(typeof(DakaContext));

            foreach (var option in services.Where(s => s.ServiceType.BaseType == typeof(DbContextOptions)).ToList())
            {
                services.Remove(option);
            }


            // Register our DbContext with the test DB connection string provided from our container
            services.AddDbContext<DakaContext>(options =>
            {
                options.UseNpgsql(_database.GetConnectionString());
            });


            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DakaContext>();
            dbContext.Database.Migrate();

            SeedDb(dbContext);
        });
    }

    private void SeedDb(DakaContext dbContext)
    {
        var seeder = new DbSeeder(dbContext);
        seeder.Seed();
    }

    public async Task InitializeAsync()
    {
        await _database.StartAsync().ConfigureAwait(false);
    }

    public new async Task DisposeAsync()
    {
        await _database.DisposeAsync().ConfigureAwait(false);
    }
}

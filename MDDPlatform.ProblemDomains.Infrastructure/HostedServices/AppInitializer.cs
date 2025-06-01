using MDDPlatform.ProblemDomains.Infrastructure.SqlDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MDDPlatform.ProblemDomains.Infrastructure.HostedServices
{
    internal class AppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly bool _migrateDatabase;

        public AppInitializer(IServiceProvider serviceProvider, bool migrateDatabase = true)
        {
            _serviceProvider = serviceProvider;
            _migrateDatabase = migrateDatabase;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (_migrateDatabase)
            {
                try
                {
                    await context.Database.MigrateAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("---> Database migration failed ...");
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
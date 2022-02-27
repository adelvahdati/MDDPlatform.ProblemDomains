using MDDPlatform.ProblemDomains.Infrastructure.Brokers;
using MDDPlatform.ProblemDomains.Infrastructure.Data;
using MDDPlatform.ProblemDomains.Infrastructure.HostedServices;
using MDDPlatform.ProblemDomains.Infrastructure.MessageHandlers;
using MDDPlatform.ProblemDomains.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.ProblemDomains.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
            services.AddHostedService<AppInitializer>();

            services.AddRabbitMQ(configuration);
            services.AddSqlDbContext(configuration);

            services.AddRepository();

            services.RegisterCommandHandler();
            services.RegisterQueryHandler();
            services.RegisterEventHandler();

            services.AddApplicationServices();

            return services;
        }
    }
}
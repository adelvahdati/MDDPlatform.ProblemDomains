using MDDPlatform.ProblemDomains.Infrastructure.HostedServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MDDPlatform.ProblemDomains.Infrastructure.Extensions.SqlDB;
using MDDPlatform.ProblemDomains.Infrastructure.Extensions.Services;
using MDDPlatform.ProblemDomains.Infrastructure.Extensions.Handlers;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.DataStorage.MongoDB;
using MDDPlatform.ProblemDomains.Infrastructure.MongoDB.Models;
using MDDPlatform.ProblemDomains.Services.Repositories;
using MDDPlatform.ProblemDomains.Infrastructure.MongoDB;

namespace MDDPlatform.ProblemDomains.Infrastructure;

public static class Extension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        services.AddRabbitMQ(configuration,"rabbitmq");
        services.AddMongoDB(configuration,"mongodb");

        services.AddMongoRespository<ProblemDomainDocument,Guid>("ProblemDomains");
        services.AddScoped<IProblemDomainRepository, ProblemDomainMongoRepository>();

        services.RegisterCommandHandler();
        services.RegisterQueryHandler();
        services.RegisterEventHandler();

        services.AddApplicationServices();

        return services;
    }
}
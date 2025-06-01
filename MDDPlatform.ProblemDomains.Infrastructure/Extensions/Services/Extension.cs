using MDDPlatform.ProblemDomains.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.ProblemDomains.Infrastructure.Extensions.Services;

public static class Extension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services){
        services.AddScoped<IProblemDomainService , ProblemDomainService>();
        return services;
    }

}
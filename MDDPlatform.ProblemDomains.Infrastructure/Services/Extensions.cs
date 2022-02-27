using MDDPlatform.ProblemDomains.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.ProblemDomains.Infrastructure.Services{
    public static class Extensions{
        public static IServiceCollection AddApplicationServices(this IServiceCollection services){
            services.AddScoped<IProblemDomainService , ProblemDomainService>();
            return services;
        }
    }
}
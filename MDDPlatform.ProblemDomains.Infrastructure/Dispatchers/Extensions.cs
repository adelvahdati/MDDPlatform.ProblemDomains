using MDDPlatform.Messages.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.ProblemDomains.Infrastructure.Dispatchers
{
    internal static class Extensions {
        internal static IServiceCollection AddMessageDispatcher(this IServiceCollection services){
            services.AddSingleton<IMessageDispatcher,MessageDispatcher>();
            return services;
        }
    }
}
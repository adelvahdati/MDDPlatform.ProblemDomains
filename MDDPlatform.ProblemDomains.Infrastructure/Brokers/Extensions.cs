using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Brokers.Configurations;
using MDDPlatform.Messages.Brokers.Options;
using MDDPlatform.Messages.Dispatchers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.ProblemDomains.Infrastructure.Brokers
{
    internal static class Extensions{
        internal static IServiceCollection AddRabbitMQ(this IServiceCollection services,IConfiguration configuration)
        {
            Console.WriteLine("---> Add RabbitMQ");
            services.AddSingleton<IMessageDispatcher,MessageDispatcher>();
            RabbitMQOption _option = new RabbitMQOption();
            configuration.GetSection("rabbitmq").Bind(_option);
            Console.WriteLine($"--->BusConfiguration : hostname= {_option.HostName}");
            services.AddSingleton<RabbitMQOption>(_option);
            services.AddSingleton<IBusConfiguration>(s=>{
                BusConfiguration busConfiguration = new BusConfiguration(_option);
                return busConfiguration;
            });
            services.AddSingleton<IMessageBroker,MessageBroker>();
            return services;
        }
    }
}
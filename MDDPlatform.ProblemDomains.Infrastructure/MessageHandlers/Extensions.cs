using MDDPlatform.Messages.Commands;
using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;
using MDDPlatform.ProblemDomains.Application.Mappers;
using MDDPlatform.ProblemDomains.Application.Queries;
using MDDPlatform.ProblemDomains.Application.Queries.Handlers;
using MDDPlatform.ProblemDomains.Services.Commands;
using MDDPlatform.ProblemDomains.Services.Commands.Handlers;
using MDDPlatform.SharedKernel.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.ProblemDomains.Infrastructure.MessageHandlers
{
    internal static class Extensions {
        internal static IServiceCollection RegisterCommandHandler(this IServiceCollection services){
            
            //AppDomain.CurrentDomain.GetAssemblies().Where( assembly=> assembly.GetType().IsAssignableTo(typeof(ICommandHandler<>)));
            
            services.AddScoped<ICommandHandler<CreateProblemDomain>, CreateProblemDomainHandler>();
            services.AddScoped<ICommandHandler<DecomposeProblemDomain>, DecomposeProblemDomainHandler>();

            return services;
        }
        internal static IServiceCollection RegisterQueryHandler(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetAllProblemDomains, IList<ProblemDomainDto>>,GetAllProblemDomainsHandler>();
            services.AddScoped<IQueryHandler<GetProblemDomainById,ProblemDomainDto>,GetProblemDomainByIdHandler>();
            services.AddScoped<IQueryHandler<GetSubDomainById,SubDomainDto>,GetSubDomainByIdHandler>();            
            services.AddScoped<IQueryHandler<GetSubDomainByName, SubDomainDto>, GetSubDomainByNameHandler>();
            services.AddScoped<IQueryHandler<GetSubDomains,IList<SubDomainDto>>,GetSubDomainsHandler>();
                        
            return services;
        }
        internal static IServiceCollection RegisterEventHandler(this IServiceCollection services){
            services.AddSingleton<IEventMapper,EventMapper>();
            return services;
        }
    }
    
}
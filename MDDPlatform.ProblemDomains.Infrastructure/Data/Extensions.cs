using MDDPlatform.ProblemDomains.Infrastructure.Data.Context;
using MDDPlatform.ProblemDomains.Infrastructure.Data.Options;
using MDDPlatform.ProblemDomains.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.ProblemDomains.Infrastructure.Data{
    internal static class Extensions{
        internal static IServiceCollection AddSqlDbContext(this IServiceCollection services , IConfiguration configuration)
        {
            
            var sqlOption = new SqlDbOption();
            configuration.GetSection("sqlserver").Bind(sqlOption);

            services.AddSingleton(sqlOption);

            services.AddDbContext<AppDbContext>(ctx => 
                                            ctx.UseSqlServer(sqlOption.ConnectionString));
        
                        
            return services;    
        }

        internal static IServiceCollection AddRepository(this IServiceCollection services){
            services.AddScoped<IProblemDomainRepository,ProblemDomainRepository>();

            return services;
        }
    }
}
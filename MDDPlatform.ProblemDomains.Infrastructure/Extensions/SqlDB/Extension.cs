using MDDPlatform.ProblemDomains.Infrastructure.SqlDB;
using MDDPlatform.ProblemDomains.Infrastructure.SqlDB.Context;
using MDDPlatform.ProblemDomains.Infrastructure.SqlDB.Options;
using MDDPlatform.ProblemDomains.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.ProblemDomains.Infrastructure.Extensions.SqlDB;

public static class Extension
{
    internal static IServiceCollection AddSqlDbContext(this IServiceCollection services , IConfiguration configuration)
    {
        
        var sqlOption = new SqlDbOption();
        configuration.GetSection("sqlserver").Bind(sqlOption);

        services.AddSingleton(sqlOption);

        services.AddDbContext<AppDbContext>(ctx => 
                                        ctx.UseSqlServer(sqlOption.ConnectionString));
    
                    
        return services;    
    }

    internal static IServiceCollection AddSqlRepository(this IServiceCollection services){
        services.AddScoped<IProblemDomainRepository,ProblemDomainSqlRepository>();

        return services;
    }

}
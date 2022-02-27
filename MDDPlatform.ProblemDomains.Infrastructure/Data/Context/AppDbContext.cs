using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.ProblemDomains.Infrastructure.Data.Configurations;
using MDDPlatform.ProblemDomains.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace MDDPlatform.ProblemDomains.Infrastructure.Data.Context{
    public class AppDbContext : DbContext
    {

        public DbSet<ProblemDomain> ProblemDomains {get;set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            var configuration = new DbConfiguration();
            modelBuilder.ApplyConfiguration<ProblemDomain>(configuration);
            modelBuilder.ApplyConfiguration<SubDomain>(configuration);
        }
        
    }
}
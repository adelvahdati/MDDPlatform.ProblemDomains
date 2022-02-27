using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.ProblemDomains.Infrastructure.Data.Context;
using MDDPlatform.ProblemDomains.Services.Repositories;
using MDDPlatform.ProblemDomains.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace MDDPlatform.ProblemDomains.Infrastructure.Data{
    public class ProblemDomainRepository : IProblemDomainRepository
    {
        private readonly DbSet<ProblemDomain> _ProblemDomains;
        private readonly AppDbContext _appDbContext;


        public ProblemDomainRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _ProblemDomains = appDbContext.ProblemDomains;
        }
        public async Task Create(ProblemDomain problemDomain)
        {
            _ProblemDomains.Add(problemDomain);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ProblemDomain> GetProblemDomain(Guid Id)
        {
            return await _ProblemDomains.Include(p=>p.SubDomains).Where(p=>p.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<ProblemDomain>> GetProblemDomains()
        {
            return await _ProblemDomains.ToListAsync();
        }

        public Task<SubDomain> GetSubDomain(Guid subDomainId)
        {
            throw new NotImplementedException();
        }

        public async Task<SubDomain?> GetSubDomain(Guid problemDomainId, string name)
        {
            var problemDomain =  await _ProblemDomains
                                    .Include(p=>p.SubDomains)
                                    .Where(p=>p.Id == problemDomainId)
                                    .FirstOrDefaultAsync();
                                    

            var subDomain = problemDomain?.SubDomains.Where(s=>s.Name.Value == name).FirstOrDefault();
            return subDomain;

        }

        public async Task<IReadOnlyList<SubDomain>> GetSubDomais(Guid problemDomainId)
        {
            ProblemDomain? problemDomain =  await _ProblemDomains
                                                                .Include(p=>p.SubDomains)
                                                                .Where(p=>p.Id == problemDomainId)
                                                                .FirstOrDefaultAsync();

            if(problemDomain == null)
                return new List<SubDomain>();
            
            return problemDomain.SubDomains;
        }

        public async Task Update(ProblemDomain problemDomain)
        {
            var subDomains = problemDomain.SubDomains;
            foreach(var item in subDomains){
                Console.WriteLine(item.Name);
            }            
            _ProblemDomains.Update(problemDomain);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
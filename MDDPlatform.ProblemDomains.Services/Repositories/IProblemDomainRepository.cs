using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.ProblemDomains.ValueObjects;

namespace MDDPlatform.ProblemDomains.Services.Repositories
{
    public interface IProblemDomainRepository
    {
        Task Create(ProblemDomain problemDomain);
        Task Update(ProblemDomain problemDomain);


        Task<ProblemDomain?> GetProblemDomain(Guid Id);
        Task<IReadOnlyList<ProblemDomain>> GetProblemDomains();


        // Task<SubDomain?> GetSubDomain(Guid subDomainId);
        Task<SubDomain?> GetSubDomain(Guid problemDomainId,string name);        
        Task<IReadOnlyList<SubDomain>> GetSubDomais(Guid problemDomainId);
        Task DeleteAsync(ProblemDomain problemDomain);
    }
}
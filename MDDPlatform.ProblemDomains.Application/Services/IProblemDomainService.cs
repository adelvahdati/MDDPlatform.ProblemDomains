using MDDPlatform.ProblemDomains.Application.DTO;

namespace MDDPlatform.ProblemDomains.Application.Services 
{
    public interface IProblemDomainService
    {
        Task CreateProblemDomain(NewProblemDomainDto problemDomain);
        Task DecomposeProblemDomain(NewSubDomainDto subDomain);
        Task<IEnumerable<ProblemDomainDto>> GetProblemDomains();
        Task<ProblemDomainDto> GetProblemDomain(Guid ProblemDomainId);
        Task<IEnumerable<SubDomainDto>> GetSubDomains(Guid ProblemDomainId);
        // Task<SubDomainDto> GetSubDomain(Guid subDomainId);
        Task<SubDomainDto> GetSubDomain(Guid problemDomainId,string subdomain);
        Task DeleteProblemdDomain(Guid id);
        Task DeleteSubDomain(Guid problemDomainId,Guid subDomainId);
    }
}
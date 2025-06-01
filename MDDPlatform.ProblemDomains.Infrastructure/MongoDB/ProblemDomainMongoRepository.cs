
using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.ProblemDomains.Infrastructure.MongoDB.Models;
using MDDPlatform.ProblemDomains.Services.Repositories;
using MDDPlatform.ProblemDomains.ValueObjects;

namespace MDDPlatform.ProblemDomains.Infrastructure.MongoDB;
public class ProblemDomainMongoRepository : IProblemDomainRepository
{
    private IMongoRepository<ProblemDomainDocument,Guid> _problemDomainRepository;

    public ProblemDomainMongoRepository(IMongoRepository<ProblemDomainDocument, Guid> problemDomainRepository)
    {
        _problemDomainRepository = problemDomainRepository;
    }

    public async Task Create(ProblemDomain problemDomain)
    {
        ProblemDomainDocument problemDomainDocument = ProblemDomainDocument.CreateFrom(problemDomain);
        await _problemDomainRepository.AddAsync(problemDomainDocument);
    }

    public async Task DeleteAsync(ProblemDomain problemDomain)
    {
        ProblemDomainDocument problemDomainDocument = ProblemDomainDocument.CreateFrom(problemDomain);
        await _problemDomainRepository.DeleteAsync(problemDomainDocument);
    }

    public async Task<ProblemDomain?> GetProblemDomain(Guid Id)
    {
        ProblemDomainDocument problemDomainDocument = await _problemDomainRepository.GetAsync(Id);
        return problemDomainDocument.ToProblemDomain();
    }

    public async Task<IReadOnlyList<ProblemDomain>> GetProblemDomains()
    {
        var problemDomainDocs =  await _problemDomainRepository.ListAsync();
        return problemDomainDocs
                .Select(problemDomainDoc=> problemDomainDoc.ToProblemDomain())
                .ToList();
    }

    // public Task<SubDomain?> GetSubDomain(Guid subDomainId)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<SubDomain?> GetSubDomain(Guid problemDomainId, string name)
    {
        ProblemDomainDocument problemDomain = await _problemDomainRepository.GetAsync(problemDomainId);
        SubDomainDocument? subDomainDocument =  problemDomain.SubDomains.Where(subDomain=> subDomain.Name == name).FirstOrDefault();
        if(subDomainDocument!=null)
            return subDomainDocument.ToSubDomain();
        else 
            return default;
    }

    public async Task<IReadOnlyList<SubDomain>> GetSubDomais(Guid problemDomainId)
    {
        ProblemDomainDocument? problemDomain = await _problemDomainRepository.GetAsync(problemDomainId);
        if(Equals(problemDomain,null))
            return new List<SubDomain>();
        
        if(problemDomain.SubDomains.Count == 0)
            return new List<SubDomain>();

        return problemDomain.SubDomains.Select(subDomainDoc=> subDomainDoc.ToSubDomain()).ToList();
    }

    public async Task Update(ProblemDomain problemDomain)
    {
        ProblemDomainDocument problemDomainDocument = ProblemDomainDocument.CreateFrom(problemDomain);
        await _problemDomainRepository.UpdateAsync(problemDomainDocument);
    }
}
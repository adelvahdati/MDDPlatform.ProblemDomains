using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.ProblemDomains.Services.Events;
public class ProblemDomainRemoved : IDomainEvent
{
    public Guid ProblemDomainId {get;set;}
    public List<Guid> DomainIds {get;set;}

    public ProblemDomainRemoved(Guid problemDomainId, List<Guid> domainIds)
    {
        ProblemDomainId = problemDomainId;
        DomainIds = domainIds;
    }
}
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.ProblemDomains.Core.Events;

public class SubDomainRemoved : IDomainEvent
{
    public Guid ProblemDomainId { get; }
    public string ProblemDomainTitle { get; }
    public Guid DomainId { get; }
    public string DomainName { get; }

    public SubDomainRemoved(Guid problemDomainId,string problemDomainTitle,Guid domainId,string domainName){
        ProblemDomainId = problemDomainId;
        ProblemDomainTitle = problemDomainTitle;
        DomainId = domainId;
        DomainName = domainName;
    }
}


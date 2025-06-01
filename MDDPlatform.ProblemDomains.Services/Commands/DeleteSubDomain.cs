using MDDPlatform.Messages.Commands;

namespace MDDPlatform.ProblemDomains.Services.Commands;
public class DeleteSubDomain : ICommand{
    public Guid ProblemDomainId {get;set;}
    public Guid DomainId {get;set;}

    public DeleteSubDomain(Guid problemDomainId, Guid domainId)
    {
        this.ProblemDomainId = problemDomainId;
        this.DomainId = domainId;
    }
}
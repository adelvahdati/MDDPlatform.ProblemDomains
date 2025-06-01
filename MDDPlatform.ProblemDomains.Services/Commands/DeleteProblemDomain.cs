using MDDPlatform.Messages.Commands;

namespace MDDPlatform.ProblemDomains.Services.Commands;
public class DeleteProblemDomain : ICommand{
    public Guid ProblemDomainId {get;set;}

    public DeleteProblemDomain(Guid problemDomainId)
    {
        ProblemDomainId = problemDomainId;
    }
}
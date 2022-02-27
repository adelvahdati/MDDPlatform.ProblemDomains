using MDDPlatform.Messages.Commands;

namespace MDDPlatform.ProblemDomains.Services.Commands{
    public class DecomposeProblemDomain : ICommand {
        public Guid ProblemDomainId {get;set;}
        public string SubDomain { get; set; }

        public DecomposeProblemDomain(Guid problemDomainId, string subDomain)
        {
            ProblemDomainId = problemDomainId;
            SubDomain = subDomain;
        }
    }
}
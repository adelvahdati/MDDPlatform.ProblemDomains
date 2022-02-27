using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;

namespace MDDPlatform.ProblemDomains.Application.Queries {
    public class GetProblemDomainById : IQuery<ProblemDomainDto>
    {
        public Guid ProblemDomainId {get;}

        public GetProblemDomainById(Guid problemDomainId)
        {
            ProblemDomainId = problemDomainId;
        }
    }
}
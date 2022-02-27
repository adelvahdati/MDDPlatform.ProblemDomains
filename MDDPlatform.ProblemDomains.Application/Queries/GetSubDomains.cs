using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;

namespace MDDPlatform.ProblemDomains.Application.Queries 
{
    public class GetSubDomains : IQuery<IList<SubDomainDto>>
    {
        public Guid ProblemDomainId {get;}

        public GetSubDomains(Guid problemDomainId)
        {
            ProblemDomainId = problemDomainId;
        }
    }
}
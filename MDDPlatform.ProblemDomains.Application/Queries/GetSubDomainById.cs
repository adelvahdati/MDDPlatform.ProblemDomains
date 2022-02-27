using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;

namespace MDDPlatform.ProblemDomains.Application.Queries {
    public class GetSubDomainById : IQuery<SubDomainDto>{
        public Guid SubDomainId {get;}

        public GetSubDomainById(Guid subDomainId)
        {
            SubDomainId = subDomainId;
        }
    }
}
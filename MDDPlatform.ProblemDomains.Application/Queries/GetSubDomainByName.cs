
using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;

namespace MDDPlatform.ProblemDomains.Application.Queries 
{
    public class GetSubDomainByName : IQuery<SubDomainDto>
    {
           public Guid ProblemDomainId {get;}
           public string Name {get;}

        public GetSubDomainByName(Guid problemDomainId, string name)
        {
            ProblemDomainId = problemDomainId;
            Name = name;
        }
    }
}
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.ProblemDomains.Events
{
    internal class ProblemDomainDecomposed : IDomainEvent
    {
        public Guid ProblemDomainId {get;}

        //public Guid SubDomainId{ get;}
        public string SubDomain { get;}

        // public ProblemDomainDecomposed(Guid problemDomainId, Guid subDomainId,string subDomain)
        // {
        //     ProblemDomainId = problemDomainId;
        //     SubDomainId = subDomainId;
        //     SubDomain = subDomain;
        // }
        public ProblemDomainDecomposed(Guid problemDomainId, string subDomain)
        {
            ProblemDomainId = problemDomainId;
            
            SubDomain = subDomain;
        }
    }
}
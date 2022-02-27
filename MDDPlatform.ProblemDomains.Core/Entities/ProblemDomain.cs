using MDDPlatform.ProblemDomains.Events;
using MDDPlatform.ProblemDomains.ValueObjects;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ProblemDomains.Entities
{
    public class ProblemDomain : BaseAggregate<Guid>
    {
        private List<SubDomain> _subDomains = new List<SubDomain>();
        public Title Title { get;}
        public Description Description {get;}
        public IReadOnlyList<SubDomain> SubDomains =>_subDomains;
        public ProblemDomain(Title title , Description description){
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
        }
        private ProblemDomain(){

        }
        public IActionStatus CreateDomain(Name name)
        {
            ISet<SubDomain> _subDomainsSet = new HashSet<SubDomain>(_subDomains);

            if(name.Equals(null))
                return TheAction.Failed("Name should not ne null");

            SubDomain domain = new SubDomain(name,this);
            var result = _subDomainsSet.Add(domain);
            if(!result)
                return TheAction.Failed($"A subdomain with the name of {name.Value} is exist");
                                                       
            //AddEvent(new ProblemDomainDecomposed(this.Id,domain.Id,name));
            _subDomains.Add(domain);
            AddEvent(new ProblemDomainDecomposed(this.Id,name));          
            return TheAction.IsDone($"Problem domain decompsed into subdomais : {name.Value}");
        }
        

    }
}
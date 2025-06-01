using MDDPlatform.ProblemDomains.Core.Events;
using MDDPlatform.ProblemDomains.Events;
using MDDPlatform.ProblemDomains.ValueObjects;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ProblemDomains.Entities
{
    public class ProblemDomain : BaseAggregate<Guid>
    {
        private List<SubDomain> _subDomains;
        public Title Title { get; private set;}
        public Description Description {get; private set;}
        public IReadOnlyList<SubDomain> SubDomains =>_subDomains;
        private ProblemDomain(Title title , Description description){
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            _subDomains = new List<SubDomain>();
        }
        private ProblemDomain(Guid id, Title title , Description description, List<SubDomain> subDomains){
            Id = id;
            Title = title;
            Description = description;
            _subDomains = subDomains;                        
        }
        public static ProblemDomain Create(string title , string description){

            return new ProblemDomain(new Title(title),new Description(description));
        }
        public static ProblemDomain Load(Guid id, string title,string description, List<SubDomain>? subDomains = null){
            if(subDomains == null)
                return new ProblemDomain(id,new Title(title),new Description(description),new List<SubDomain>());

            return new ProblemDomain(id,new Title(title),new Description(description),subDomains);
        }
        public IActionStatus CreateDomain(Name name)
        {
            ISet<SubDomain> _subDomainsSet = new HashSet<SubDomain>(_subDomains);

            if(name.Equals(null))
                return TheAction.Failed("Name should not ne null");

            SubDomain domain = SubDomain.Create(name.Value);
            var result = _subDomainsSet.Add(domain);
            if(!result)
                return TheAction.Failed($"A subdomain with the name of {name.Value} is exist");
                                                       
            
            _subDomains.Add(domain);
            AddEvent(new ProblemDomainDecomposed(this.Id,domain.TraceId.Value,name));          
            return TheAction.IsDone($"Problem domain decompsed into subdomais : {name.Value}");
        }
        public void RemoveSubDomain(SubDomain domain)
        {
            _subDomains.RemoveAll(SubDomain=>SubDomain.TraceId.Value == domain.TraceId.Value);
            AddEvent(new SubDomainRemoved(Id,Title,domain.TraceId.Value,domain.Name));
        }       
    }
}
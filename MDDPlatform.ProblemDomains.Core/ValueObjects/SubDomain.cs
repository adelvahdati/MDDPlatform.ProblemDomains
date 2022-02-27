using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ProblemDomains.ValueObjects
{
    public class SubDomain : ValueObject
    {
        //public Guid Id {get;}
        public Name Name { get; }
        public ProblemDomain ProblemDomain { get; }

        public SubDomain(Name name, ProblemDomain problemDomain)
        {
            Name = name;
            ProblemDomain = problemDomain;
            //Id = Guid.NewGuid();
        }
        public SubDomain(Guid id, Name name, ProblemDomain problemDomain)
        {
            Name = name;
            ProblemDomain = problemDomain;
            //Id = id;
        }
        private SubDomain(){
            
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.Value;
            yield return ProblemDomain.Id;
        }
    }
}
using MDDPlatform.SharedKernel.ValueObjects;

namespace MDDPlatform.ProblemDomains.ValueObjects
{
    public class SubDomain : TraceableValueObject
    {
        public Name Name { get; private set;}
        private SubDomain(Guid id, string name){
            TraceId = TraceId.Load(id);
            Name = new Name(name);
        }
        private SubDomain(string name){
            TraceId = TraceId.Create();
            Name = new Name(name);
        }

        public static SubDomain Create(string name){
            return new SubDomain(name);
        }
        public static SubDomain Load(Guid id , string name){
            return new SubDomain(id,name);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.Value;
        }
    }
}
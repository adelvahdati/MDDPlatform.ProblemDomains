using MDDPlatform.ProblemDomains.ValueObjects;

namespace MDDPlatform.ProblemDomains.Application.DTO
{
    public class SubDomainDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public SubDomainDto(Guid id, string name)
        {
            Id=id;
            Name = name;
        }


        internal static SubDomainDto MapFrom(SubDomain subDomain)
        {
            return new SubDomainDto(subDomain.TraceId.Value,subDomain.Name.Value);
        }
    }
}
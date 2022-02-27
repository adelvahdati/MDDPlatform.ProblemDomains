using MDDPlatform.ProblemDomains.ValueObjects;

namespace MDDPlatform.ProblemDomains.Application.DTO
{
    public class SubDomainDto 
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProblemDomainId {get;set;}

        // public SubDomainDto(Guid id, string name,Guid problemDomainId)
        // {
        //     Id = id;
        //     Name = name;
        //     ProblemDomainId = problemDomainId;
        // }
        public SubDomainDto(string name,Guid problemDomainId)
        {
            Name = name;
            ProblemDomainId = problemDomainId;
        }


        internal static SubDomainDto MapFrom(SubDomain subDomain)
        {
            //return new SubDomainDto(subDomain.Id,subDomain.Name.Value,subDomain.ProblemDomain.Id);
            return new SubDomainDto(subDomain.Name.Value,subDomain.ProblemDomain.Id);
        }
    }
}
using MDDPlatform.ProblemDomains.Entities;

namespace MDDPlatform.ProblemDomains.Application.DTO
{
    public class ProblemDomainDto
    {
        public Guid Id {get;set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SubDomainDto> SubDomains { get; set; }
        public ProblemDomainDto(Guid id,string title, string description, List<SubDomainDto> subDomains)
        {
            Id = id;
            Title = title;
            Description = description;
            SubDomains = subDomains;
        }
        internal static ProblemDomainDto MapFrom(ProblemDomain problemDomain){
            List<SubDomainDto> subDomains = new List<SubDomainDto>();
            var problemDomainId = problemDomain.Id;
            var title = problemDomain.Title.Value;
            var description = problemDomain.Description.Value;
            
            if(description == null)
                description = string.Empty;
            
            foreach(var item in problemDomain.SubDomains)
            {
                //var subDomain = new SubDomainDto(item.Id,item.Name.Value,item.ProblemDomain.Id);
                var subDomain = new SubDomainDto(item.Name.Value,item.ProblemDomain.Id);
                subDomains.Add(subDomain);
            }
            return new ProblemDomainDto(problemDomainId,title,description,subDomains);
        }
    }
}
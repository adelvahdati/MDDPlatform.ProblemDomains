namespace MDDPlatform.ProblemDomains.Application.DTO{
    public class NewSubDomainDto
    {
        public string Name { get; set; }
        public Guid ProblemDomainId {get;set;}

        public NewSubDomainDto(string name, Guid problemDomainId)
        {
            Name = name;
            ProblemDomainId = problemDomainId;
        }
    }
}
using MDDPlatform.Messages.Commands;

namespace MDDPlatform.ProblemDomains.Services.Commands{
    public class CreateProblemDomain : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public CreateProblemDomain(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
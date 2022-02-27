using MDDPlatform.Messages.Commands;
using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.ProblemDomains.Services.Repositories;
using MDDPlatform.ProblemDomains.ValueObjects;

namespace MDDPlatform.ProblemDomains.Services.Commands.Handlers
{
    public class CreateProblemDomainHandler : ICommandHandler<CreateProblemDomain>
    {
        private readonly IProblemDomainRepository _problemDomainRepository;

        public CreateProblemDomainHandler(IProblemDomainRepository problemDomainRepository)
        {
            _problemDomainRepository = problemDomainRepository;
        }
        public void Handle(CreateProblemDomain command)
        {
            throw new NotImplementedException();
        }

        public async Task HandleAsync(CreateProblemDomain command)
        {
            Title title = new Title(command.Title);
            Description description = new Description(command.Description);
            var problemDomain = new ProblemDomain(title,description);
            await _problemDomainRepository.Create(problemDomain);
        }
    }
}
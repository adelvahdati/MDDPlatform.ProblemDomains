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
            var problemDomain = ProblemDomain.Create(command.Title,command.Description);
            await _problemDomainRepository.Create(problemDomain);
        }
    }
}
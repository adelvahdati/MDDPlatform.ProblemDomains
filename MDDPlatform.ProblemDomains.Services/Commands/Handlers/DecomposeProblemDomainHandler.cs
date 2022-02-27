using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ProblemDomains.Services.Repositories;
using MDDPlatform.ProblemDomains.ValueObjects;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.ProblemDomains.Services.Commands.Handlers
{
    public class DecomposeProblemDomainHandler : ICommandHandler<DecomposeProblemDomain>
    {
        private readonly IProblemDomainRepository _problemDomainRepository;
        private readonly IMessageBroker _messageBroker;
        private readonly IEventMapper _eventMapper;

        public DecomposeProblemDomainHandler(IProblemDomainRepository problemDomainRepository, IMessageBroker messageBroker , IEventMapper eventMapper)
        {
            _problemDomainRepository = problemDomainRepository;
            _messageBroker = messageBroker;
            _eventMapper = eventMapper;
        }
        public void Handle(DecomposeProblemDomain command)
        {
            throw new NotImplementedException();
        }

        public async Task HandleAsync(DecomposeProblemDomain command)
        {
            var problemDomain = await _problemDomainRepository.GetProblemDomain(command.ProblemDomainId);

            Name name = new Name(command.SubDomain);
            var action =  problemDomain.CreateDomain(name);
            if(action.Status == ActionStatus.Failure){
                Console.WriteLine(action.Message);
                return;
            }
            await _problemDomainRepository.Update(problemDomain);
            var events = _eventMapper.Map(problemDomain.DomainEvents);
            await _messageBroker.PublishAsync(events);            
            problemDomain.ClearEvents();            
        }
    }
}
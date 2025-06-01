using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ProblemDomains.Services.Events;
using MDDPlatform.ProblemDomains.Services.Repositories;
using MDDPlatform.ProblemDomains.ValueObjects;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.ProblemDomains.Services.Commands.Handlers;
public class DeleteProblemDomainHandler : ICommandHandler<DeleteProblemDomain>
{
    private readonly IProblemDomainRepository _problemDomainRepository;
    private readonly IMessageBroker _messageBroker;
    private readonly IEventMapper _eventMapper;

    public DeleteProblemDomainHandler(IProblemDomainRepository problemDomainRepository, IMessageBroker messageBroker, IEventMapper eventMapper)
    {
        _problemDomainRepository = problemDomainRepository;
        _messageBroker = messageBroker;
        _eventMapper = eventMapper;
    }

    public void Handle(DeleteProblemDomain command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeleteProblemDomain command)
    {
        var problemDomain = await _problemDomainRepository.GetProblemDomain(command.ProblemDomainId);
        if(Equals(problemDomain,null))
            throw new Exception("Problem Domain Not Found");
        
        await _problemDomainRepository.DeleteAsync(problemDomain);
        List<Guid> domainIds = problemDomain.SubDomains != null? 
                                    problemDomain.SubDomains.Select(domain=>domain.TraceId.Value).ToList() : 
                                    new();

        var @event = new ProblemDomainRemoved(problemDomain.Id,domainIds);
        await _messageBroker.PublishAsync(_eventMapper.Map(@event));        
    }
}
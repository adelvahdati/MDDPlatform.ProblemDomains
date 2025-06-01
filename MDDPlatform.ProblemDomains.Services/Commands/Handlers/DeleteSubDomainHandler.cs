using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.ProblemDomains.Services.Repositories;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.ProblemDomains.Services.Commands.Handlers;
public class DeleteSubDomainHandler : ICommandHandler<DeleteSubDomain>
{
    private readonly IProblemDomainRepository _problemDomainRepository;
    private readonly IMessageBroker _messageBroker;
    private readonly IEventMapper _eventMapper;

    public DeleteSubDomainHandler(IProblemDomainRepository problemDomainRepository, IMessageBroker messageBroker, IEventMapper eventMapper)
    {
        _problemDomainRepository = problemDomainRepository;
        _messageBroker = messageBroker;
        _eventMapper = eventMapper;
    }

    public void Handle(DeleteSubDomain command)
    {
        throw new NotImplementedException();
    }

    public async Task HandleAsync(DeleteSubDomain command)
    {
        ProblemDomain? problemDomain = await _problemDomainRepository.GetProblemDomain(command.ProblemDomainId);
        if(Equals(problemDomain,null))
            throw new Exception("Problem Domain Not Found");
        var subDomain = problemDomain.SubDomains.FirstOrDefault(d=>d.TraceId.Value == command.DomainId);
        if(Equals(subDomain,null))
            throw new Exception("Sub Domain Not Found");
        
        problemDomain.RemoveSubDomain(subDomain);        
        await _problemDomainRepository.Update(problemDomain);
        var events = _eventMapper.Map(problemDomain.DomainEvents);
        await _messageBroker.PublishAsync(events);            
        problemDomain.ClearEvents();            

    }
}
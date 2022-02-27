using MDDPlatform.Messages.Events;
using MDDPlatform.SharedKernel.Events;
using MDDPlatform.SharedKernel.Mappers;

namespace MDDPlatform.ProblemDomains.Application.Mappers
{
    public class EventMapper : IEventMapper
    {
        public IEvent Map(IDomainEvent @event)
        {
            return @event;
        }

        public IEnumerable<IEvent> Map(IEnumerable<IDomainEvent> events)
        {
            foreach(var @event in events){
                yield return @event;
            }
        }
    }
}
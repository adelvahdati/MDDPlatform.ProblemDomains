using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;
using MDDPlatform.ProblemDomains.Services.Repositories;

namespace MDDPlatform.ProblemDomains.Application.Queries.Handlers {
    public class GetSubDomainsHandler : IQueryHandler<GetSubDomains, IList<SubDomainDto>>
    {
        private readonly IProblemDomainRepository _problemDomainRepository;

        public GetSubDomainsHandler(IProblemDomainRepository problemDomainRepository)
        {
            _problemDomainRepository = problemDomainRepository;
        }
        public IList<SubDomainDto> Handle(GetSubDomains query)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<SubDomainDto>> HandleAsync(GetSubDomains query)
        {
            var subDomains = await _problemDomainRepository.GetSubDomais(query.ProblemDomainId);
            var subDomainsDto = subDomains.Select(c=>SubDomainDto.MapFrom(c)).ToList();
            return subDomainsDto;
        }
    }
}
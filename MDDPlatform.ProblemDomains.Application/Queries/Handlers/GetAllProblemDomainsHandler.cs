using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;
using MDDPlatform.ProblemDomains.Services.Repositories;

namespace MDDPlatform.ProblemDomains.Application.Queries.Handlers {
    public class GetAllProblemDomainsHandler : IQueryHandler<GetAllProblemDomains, IList<ProblemDomainDto>>
    {
        private readonly IProblemDomainRepository _problemDomainRepository;

        public GetAllProblemDomainsHandler(IProblemDomainRepository problemDomainRepository)
        {
            _problemDomainRepository = problemDomainRepository;
        }
        public IList<ProblemDomainDto> Handle(GetAllProblemDomains query)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProblemDomainDto>> HandleAsync(GetAllProblemDomains query)
        {
            IList<ProblemDomainDto> problemDomainDtos = new List<ProblemDomainDto>();
            var problemDomains = await _problemDomainRepository.GetProblemDomains();
            foreach(var item in problemDomains){
                var problemDomainDto = ProblemDomainDto.MapFrom(item);
                problemDomainDtos.Add(problemDomainDto);
            }
            return problemDomainDtos;
        }
    }
}
using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;
using MDDPlatform.ProblemDomains.Services.Repositories;

namespace MDDPlatform.ProblemDomains.Application.Queries.Handlers
{
    public class GetProblemDomainByIdHandler : IQueryHandler<GetProblemDomainById, ProblemDomainDto>
    {
        private readonly IProblemDomainRepository _problemDomainRepository;

        public GetProblemDomainByIdHandler(IProblemDomainRepository problemDomainRepository)
        {
            _problemDomainRepository = problemDomainRepository;
        }
        public ProblemDomainDto Handle(GetProblemDomainById query)
        {
            throw new NotImplementedException();
        }

        public async Task<ProblemDomainDto> HandleAsync(GetProblemDomainById query)
        {
            var problemDomain  = await _problemDomainRepository.GetProblemDomain(query.ProblemDomainId);
            return ProblemDomainDto.MapFrom(problemDomain);
        }
    }
}
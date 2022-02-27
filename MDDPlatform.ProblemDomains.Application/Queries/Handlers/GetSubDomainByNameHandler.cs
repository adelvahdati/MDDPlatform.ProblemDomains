using MDDPlatform.Messages.Queries;
using MDDPlatform.ProblemDomains.Application.DTO;
using MDDPlatform.ProblemDomains.Services.Repositories;

namespace MDDPlatform.ProblemDomains.Application.Queries.Handlers
{
    public class GetSubDomainByNameHandler : IQueryHandler<GetSubDomainByName, SubDomainDto>
    {
        private readonly IProblemDomainRepository _problemDomainRepository;

        public GetSubDomainByNameHandler(IProblemDomainRepository problemDomainRepository)
        {
            _problemDomainRepository = problemDomainRepository;
        }
        public SubDomainDto Handle(GetSubDomainByName query)
        {
            throw new NotImplementedException();
        }

        public async Task<SubDomainDto> HandleAsync(GetSubDomainByName query)
        {
            var subDomain =  await _problemDomainRepository.GetSubDomain(query.ProblemDomainId,query.Name);
            return SubDomainDto.MapFrom(subDomain);
        }
    }
}
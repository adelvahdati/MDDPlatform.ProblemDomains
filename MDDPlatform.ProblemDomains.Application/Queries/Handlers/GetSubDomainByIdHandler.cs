// using MDDPlatform.Messages.Queries;
// using MDDPlatform.ProblemDomains.Application.DTO;
// using MDDPlatform.ProblemDomains.Services.Repositories;

// namespace MDDPlatform.ProblemDomains.Application.Queries.Handlers {
//     public class GetSubDomainByIdHandler : IQueryHandler<GetSubDomainById, SubDomainDto>
//     {
//         private readonly IProblemDomainRepository _problemDomainRepository;

//         public GetSubDomainByIdHandler(IProblemDomainRepository problemDomainRepository)
//         {
//             _problemDomainRepository = problemDomainRepository;
//         }
//         public SubDomainDto Handle(GetSubDomainById query)
//         {
//             throw new NotImplementedException();
//         }

//         public async Task<SubDomainDto> HandleAsync(GetSubDomainById query)
//         {
//             var subDomain = await _problemDomainRepository.GetSubDomain(query.SubDomainId);
//             return SubDomainDto.MapFrom(subDomain);
//         }
//     }
// }
using MDDPlatform.ProblemDomains.Application.DTO;
using MDDPlatform.ProblemDomains.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.ProblemDomains.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProblemDomainController : ControllerBase
    {
        private readonly IProblemDomainService _problemDomainService;

        public ProblemDomainController(IProblemDomainService problemDomainService)
        {
            _problemDomainService = problemDomainService;
        }

        [HttpPost("Create")]
        public async Task Create([FromBody] NewProblemDomainDto problemDomain)
        {
            await _problemDomainService.CreateProblemDomain(problemDomain);

        }
        [HttpPost("Decompose")]
        public async Task Decompose([FromBody] NewSubDomainDto newSubDomain)
        {
            await _problemDomainService.DecomposeProblemDomain(newSubDomain);
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _problemDomainService.DeleteProblemdDomain(id);

        }
        [HttpDelete("{problemDomainId}/{domainId}")]
        public async Task DeleteSubDomain(Guid problemDomainId,Guid domainId)
        {
            await _problemDomainService.DeleteSubDomain(problemDomainId,domainId);
        }
        [HttpGet("{problemDomainId:guid}/SubDomains")]
        public async Task<IEnumerable<SubDomainDto>> GetSubDomains([FromRoute] Guid problemDomainId)
        {
            return await _problemDomainService.GetSubDomains(problemDomainId);
        }
        [HttpGet("{problemDomainId:guid}/SubDomains/{name}")]
        public async Task<SubDomainDto> GetSubdomainByName([FromRoute] Guid problemDomainId, string name)
        {
            return await _problemDomainService.GetSubDomain(problemDomainId, name);
        }

        [HttpGet("{problemDomainId:guid}")]
        public async Task<ProblemDomainDto?> GetProblemDomainAsync([FromRoute] Guid problemDomainId)
        {
            return await _problemDomainService.GetProblemDomain(problemDomainId);
        }

        [HttpGet]
        public async Task<IEnumerable<ProblemDomainDto>?> GetProblemDomainsAsync()
        {
            return await _problemDomainService.GetProblemDomains();
        }

    }

}
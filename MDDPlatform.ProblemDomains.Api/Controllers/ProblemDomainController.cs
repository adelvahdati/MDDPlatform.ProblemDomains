using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ProblemDomains.Application.DTO;
using MDDPlatform.ProblemDomains.Application.Queries;
using MDDPlatform.ProblemDomains.Application.Services;
using MDDPlatform.ProblemDomains.Services.Commands;
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
        public async Task Create([FromBody] NewProblemDomainDto problemDomain){
            await _problemDomainService.CreateProblemDomain(problemDomain);
            Console.WriteLine($" Problem Domain Created : title={problemDomain.Title} - description={problemDomain.Description}");

        }
        [HttpGet]
        public async Task<IList<ProblemDomainDto>> ProblemDomains(){
            return (await _problemDomainService.GetProblemDomains()).ToList();
        }
        [HttpPost("Decompose")]
        public async Task Decompose([FromBody] NewSubDomainDto newSubDomain)
        {
            await _problemDomainService.DecomposeProblemDomain(newSubDomain);
        }
        [HttpGet("{problemDomainId:guid}/SubDomains")]
        public async Task<IEnumerable<SubDomainDto>> GetSubDomains([FromRoute] Guid problemDomainId)
        {
            return await _problemDomainService.GetSubDomains(problemDomainId);
        }
        [HttpGet("{problemDomainId}/SubDomain/{name}")]
        public async Task<SubDomainDto> GetSubdomain([FromRoute] Guid problemDomainId,string name){
            return await _problemDomainService.GetSubDomain(problemDomainId,name);
        }
        [HttpGet("SubDomain/{subDomainId:guid}")]
        public async Task<SubDomainDto> GetSubDomain([FromRoute] Guid subDomainId){
            return await _problemDomainService.GetSubDomain(subDomainId);
        }
    }

}
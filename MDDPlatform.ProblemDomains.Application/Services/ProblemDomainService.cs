using MDDPlatform.Messages.Dispatchers;
using MDDPlatform.ProblemDomains.Application.DTO;
using MDDPlatform.ProblemDomains.Application.Queries;
using MDDPlatform.ProblemDomains.Services.Commands;

namespace MDDPlatform.ProblemDomains.Application.Services
{
    public class ProblemDomainService : IProblemDomainService
    {
        private readonly IMessageDispatcher _messageDispatcher;

        public ProblemDomainService(IMessageDispatcher messageDispatcher)
        {
            _messageDispatcher = messageDispatcher;
        }
        
        public  async Task CreateProblemDomain(NewProblemDomainDto problemDomain)
        {
            CreateProblemDomain command = new CreateProblemDomain(problemDomain.Title,problemDomain.Description);
            await _messageDispatcher.HandleAsync(command);
        }

        public async Task DecomposeProblemDomain(NewSubDomainDto subDomain)
        {
            DecomposeProblemDomain command = new DecomposeProblemDomain(subDomain.ProblemDomainId,subDomain.Name);
            await _messageDispatcher.HandleAsync(command);
        }

        public async Task<ProblemDomainDto> GetProblemDomain(Guid ProblemDomainId)
        {
            var query = new GetProblemDomainById(ProblemDomainId);
            return await _messageDispatcher.HandleAsync<ProblemDomainDto>(query);
        }

        public async Task<IEnumerable<ProblemDomainDto>> GetProblemDomains()
        {
            var query = new GetAllProblemDomains();
            return await _messageDispatcher.HandleAsync<IList<ProblemDomainDto>>(query);
        }

        public async Task<SubDomainDto> GetSubDomain(Guid subDomainId)
        {
            var query = new GetSubDomainById(subDomainId);
            return await _messageDispatcher.HandleAsync<SubDomainDto>(query);
        }

        public async Task<SubDomainDto> GetSubDomain(Guid problemDomainId, string subdomain)
        {
            var query = new GetSubDomainByName(problemDomainId,subdomain);
            return await _messageDispatcher.HandleAsync<SubDomainDto>(query);
        }

        public async Task<IEnumerable<SubDomainDto>> GetSubDomains(Guid problemDomainId)
        {
            var query = new GetSubDomains(problemDomainId);
            return await _messageDispatcher.HandleAsync<IList<SubDomainDto>>(query);
        }
    }
}
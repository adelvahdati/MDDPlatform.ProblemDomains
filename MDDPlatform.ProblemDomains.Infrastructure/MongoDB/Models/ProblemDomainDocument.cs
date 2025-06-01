using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ProblemDomains.Infrastructure.MongoDB.Models;
public class ProblemDomainDocument : BaseEntity<Guid>
{
        public string Title { get;set;}
        public string Description {get;set;}
        public List<SubDomainDocument> SubDomains {get;set;}

    public ProblemDomainDocument(Guid id, string title, string description, List<SubDomainDocument> subDomains)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.SubDomains = subDomains;    
    }
    public static ProblemDomainDocument CreateFrom(ProblemDomain problemDomain)
    {
        
        var subDomainDocs = problemDomain.SubDomains
                                            .Select(subDomain=> SubDomainDocument.CreateFrom(subDomain))
                                            .ToList();

        string? descriptionValue = problemDomain.Description.Value;
        string description = descriptionValue == null? "" : descriptionValue;

        return new ProblemDomainDocument(problemDomain.Id,problemDomain.Title.Value,description,subDomainDocs);
    }
    public ProblemDomain ToProblemDomain(){
        var subDomains = SubDomains.Select(subDomainDoc=> subDomainDoc.ToSubDomain()).ToList();
        return ProblemDomain.Load(Id,Title,Description,subDomains);
    }
}
using MDDPlatform.ProblemDomains.ValueObjects;

namespace MDDPlatform.ProblemDomains.Infrastructure.MongoDB.Models;
public class SubDomainDocument
{
    public Guid Id {get;set;}
    public string Name {get;set;}

    public SubDomainDocument(Guid traceId, string name)
    {
        Id = traceId;
        Name = name;
    }
    public static SubDomainDocument CreateFrom(SubDomain subDomain){    
        return new SubDomainDocument(subDomain.TraceId.Value,subDomain.Name.Value);        
    }

    public SubDomain ToSubDomain()
    {
        return SubDomain.Load(Id,Name);
    }
}
using MDDPlatform.ProblemDomains.Entities;
using MDDPlatform.ProblemDomains.ValueObjects;
using MDDPlatform.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace MDDPlatform.ProblemDomains.Infrastructure.SqlDB.Configurations;
public class DbConfiguration : IEntityTypeConfiguration<ProblemDomain>, IEntityTypeConfiguration<SubDomain>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProblemDomain> builder)
    {
        builder.HasKey(pd=>pd.Id);
        var titleConverter  = new ValueConverter<Title,string>(title => title.Value, value => new Title(value));
        var descriptionConverter = new ValueConverter<Description,string?>(description=> description.Value,value=>new Description(value));

        builder
            .Property(pd=>pd.Title)
            .HasConversion(titleConverter)
            .HasColumnName("Title");

        builder
            .Property(pd=>pd.Description)
            .HasConversion(descriptionConverter)
            .HasColumnName("Description");
        
        builder.HasMany(pd=> pd.SubDomains);

        builder.ToTable("ProblemDomains");
    }

    public void Configure(EntityTypeBuilder<SubDomain> builder)
    {
        builder.HasKey(p=>p.TraceId).HasName("Id");
        builder.Property(p=>p.TraceId)
                .HasConversion(traceId=> traceId.Value,id=>TraceId.Load(id))
                .HasColumnName("Id");
        builder
            .Property(p=>p.Name)
            .HasConversion(n=>n.Value,val=> new Name(val));
        
        builder.ToTable("SubDomains");                        
    }
}
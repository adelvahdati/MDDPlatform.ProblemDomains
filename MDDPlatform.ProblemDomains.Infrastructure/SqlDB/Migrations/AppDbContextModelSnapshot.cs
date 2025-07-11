﻿// <auto-generated />
using MDDPlatform.ProblemDomains.Infrastructure.SqlDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace MDDPlatform.ProblemDomains.Infrastructure.SqlDB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MDDPlatform.ProblemDomains.Entities.ProblemDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("ProblemDomains", (string)null);
                });

            modelBuilder.Entity("MDDPlatform.ProblemDomains.ValueObjects.SubDomain", b =>
                {
                    b.Property<Guid>("TraceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProblemDomainId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TraceId")
                        .HasName("Id");

                    b.HasIndex("ProblemDomainId");

                    b.ToTable("SubDomains", (string)null);
                });

            modelBuilder.Entity("MDDPlatform.ProblemDomains.ValueObjects.SubDomain", b =>
                {
                    b.HasOne("MDDPlatform.ProblemDomains.Entities.ProblemDomain", "ProblemDomain")
                        .WithMany("SubDomains")
                        .HasForeignKey("ProblemDomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProblemDomain");
                });

            modelBuilder.Entity("MDDPlatform.ProblemDomains.Entities.ProblemDomain", b =>
                {
                    b.Navigation("SubDomains");
                });
#pragma warning restore 612, 618
        }
    }
}

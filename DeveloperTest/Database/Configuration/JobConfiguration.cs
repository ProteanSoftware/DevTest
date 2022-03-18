using System;
using DeveloperTest.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperTest.Database.Configuration;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(x => x.JobId);

        builder.Property(x => x.JobId)
            .ValueGeneratedOnAdd();

        builder.HasData(new Job
        {
            JobId = 1,
            Engineer = "Test",
            When = new DateTime(2022, 2, 1, 12, 0, 0)
        });
    }
}
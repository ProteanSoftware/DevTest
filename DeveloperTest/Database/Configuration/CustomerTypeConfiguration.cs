using System;
using System.Linq;
using DeveloperTest.Database.Models;
using DeveloperTest.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperTest.Database.Configuration;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
{
    public void Configure(EntityTypeBuilder<CustomerType> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion<byte>();

        builder.HasData(
            Enum.GetValues(typeof(CustomerTypeId))
                .Cast<CustomerTypeId>()
                .Select(e => new CustomerType()
                {
                    Id = e,
                    Name = e.ToString()
                }));
    }
}
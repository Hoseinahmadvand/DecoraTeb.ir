using DecoraTeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecoraTeb.Data.Configurations;

public class ServiceConfiguraton : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
       // builder.ToTable();
    }
}

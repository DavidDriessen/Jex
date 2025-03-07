using Jex.Persistence.Abstraction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jex.Persistence.Configurations;

public class CompanyEntityConfiguration: IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name);
        builder.Property(c => c.Address);

        builder.HasMany(c => c.Vacancies)
            .WithOne(v=>v.Company);
    }
}
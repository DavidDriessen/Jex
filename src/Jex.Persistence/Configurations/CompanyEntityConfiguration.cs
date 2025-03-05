using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jex.Persistence.Configurations;

public class CompanyEntityConfiguration: IEntityTypeConfiguration<Abstraction.Models.web.CompanyWithVacancies>
{
    public void Configure(EntityTypeBuilder<Abstraction.Models.web.CompanyWithVacancies> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name);
        builder.Property(c => c.Address);

        builder.HasMany(c => c.Vacancies);
    }
}
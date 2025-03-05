using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jex.Persistence.Configurations;

public class VacancyEntityConfiguration: IEntityTypeConfiguration<Abstraction.Models.Backoffice.Vacancy>
{
    public void Configure(EntityTypeBuilder<Abstraction.Models.Backoffice.Vacancy> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title);
        builder.Property(c => c.Description);
    }
}
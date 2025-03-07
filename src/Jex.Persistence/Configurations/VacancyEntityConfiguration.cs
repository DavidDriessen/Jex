using Jex.Persistence.Abstraction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jex.Persistence.Configurations;

public class VacancyEntityConfiguration: IEntityTypeConfiguration<Vacancy>
{
    public void Configure(EntityTypeBuilder<Vacancy> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title);
        builder.Property(c => c.Description);
        builder.Property(c => c.State);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jex.Persistence.Configurations;

public class CompanyEntityConfiguration: IEntityTypeConfiguration<Abstraction.Models.Backoffice.Company>
{
    public void Configure(EntityTypeBuilder<Abstraction.Models.Backoffice.Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name);
        builder.Property(c => c.Address);
    }
}
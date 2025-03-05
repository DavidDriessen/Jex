using Jex.Persistence.Abstraction.Models.Backoffice;
using Jex.Persistence.Abstraction.Models.web;
using Microsoft.EntityFrameworkCore;

namespace Jex.Persistence.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyWithVacancies> CompaniesWithVacancies { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }

    private string DbPath { get; }

    public DatabaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "database.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}
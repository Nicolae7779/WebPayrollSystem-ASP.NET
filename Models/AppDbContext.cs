using System.Data.Entity;
using WebApplication10.Models;

public class AppDbContext : DbContext
{
    public DbSet<Angajati> Angajati { get; set; }
    public DbSet<ImpozitTable> Impozite { get; set; }
}
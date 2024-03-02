using Microsoft.EntityFrameworkCore;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<MyEntity> MyEntities { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: Configure schema details using Fluent API
    }
}
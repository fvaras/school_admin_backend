using Microsoft.EntityFrameworkCore;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<StudentGuardian> StudentGuardians { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: Configure schema details using Fluent API

        base.OnModelCreating(modelBuilder);

        // Example of a many-to-many relationship configuration for Teacher and Grade
        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Grades)
            .WithMany(c => c.Teachers)
            .UsingEntity(j => j.ToTable("TeacherGrades")); // Specify the join table name

        // // Configuring a one-to-many relationship with cascade delete
        // modelBuilder.Entity<Student>()
        //     .HasOne(s => s.Grade)
        //     .WithMany(c => c.Students)
        //     .HasForeignKey(s => s.GradeId)
        //     .OnDelete(DeleteBehavior.Restrict); // This is optional based on your cascade delete needs

        // // Configuring the optional one-to-one relationship for a Student and their main guardian
        // modelBuilder.Entity<Student>()
        //     .HasOne(s => s.MainStudentGuardian)
        //     .WithOne()
        //     .HasForeignKey<Student>(s => s.MainStudentGuardianId)
        //     .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete if the main guardian is deleted
    }
}
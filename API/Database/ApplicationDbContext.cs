using Microsoft.EntityFrameworkCore;
using school_admin_api.Database.Configurations;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<CalendarEvent> CalendarEvents { get; set; }
    public DbSet<Subject> Subject { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: Configure schema details using Fluent API

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new CalendarConfiguration());

        modelBuilder.Entity<User>()
            .HasMany(t => t.Profiles)
            .WithMany(c => c.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserProfiles", // This is the name of the join table
                j => j.HasOne<Profile>().WithMany().HasForeignKey("ProfileId"),
                j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                j =>
                {
                    // Seeding the relationship
                    j.HasData(
                        new { UserId = 1, ProfileId = 1 } // Associates User with Id 1 to Profile with Id 1
                    );
                });

        // many-to-many relationship configuration for Teacher and Grade
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
        //     .HasOne(s => s.MainGuardian)
        //     .WithOne()
        //     .HasForeignKey<Student>(s => s.MainGuardianId)
        //     .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete if the main guardian is deleted
    }
}
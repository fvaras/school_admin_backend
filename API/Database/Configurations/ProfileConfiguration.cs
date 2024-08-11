using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_admin_api.Model;

namespace school_admin_api.Database.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasData(
            new Profile() { Id = Profile.ADMINISTRATOR, Name = "Administrator" },
            new Profile() { Id = Profile.TEACHER, Name = "Teacher" },
            new Profile() { Id = Profile.STUDENT, Name = "Student" },
            new Profile() { Id = Profile.GUARDIAN, Name = "Guardian" }
        );
    }
}

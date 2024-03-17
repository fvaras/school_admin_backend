using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_admin_api.Model;
using static school_admin_api.Model.Profile;

namespace school_admin_api.Database.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasData(
            new Profile() { Id = (int)PROFILES_TYPES.ADMINISTRATOR, Name = "Administrator" },
            new Profile() { Id = (int)PROFILES_TYPES.TEACHER, Name = "Teacher" },
            new Profile() { Id = (int)PROFILES_TYPES.STUDENT, Name = "Student" },
            new Profile() { Id = (int)PROFILES_TYPES.GUARDIAN, Name = "Guardian" }
        );
    }
}

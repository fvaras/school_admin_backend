using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_admin_api.Model;

namespace school_admin_api.Repository.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(up => new { up.UserId, up.ProfileId });

        builder.HasOne(up => up.User)
               .WithMany(u => u.UserProfiles)
               .HasForeignKey(up => up.UserId);

        builder.HasOne(up => up.Profile)
               .WithMany(p => p.UserProfiles)
               .HasForeignKey(up => up.ProfileId);

        builder.HasData(
            new UserProfile { UserId = Guid.Parse("845900f3-b438-4461-9ef0-3aa846085000"), ProfileId = Profile.ADMINISTRATOR },
            new UserProfile { UserId = Guid.Parse("ea8108dc-3e1d-42ab-a932-9016b22e717e"), ProfileId = Profile.ADMINISTRATOR },
            new UserProfile { UserId = Guid.Parse("ea8108dc-3e1d-42ab-a932-9016b22e717e"), ProfileId = Profile.TEACHER }
        );
    }
}
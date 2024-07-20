using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_admin_api.Model;

namespace school_admin_api.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User()
            {
                Id = Guid.Parse("845900f3-b438-4461-9ef0-3aa846085000"),
                UserName = "admin",
                Password = "admin",
                Rut = "19",
                FirstName = "admin",
                LastName = "",
                Email = "fdovarasc@gmail.com",
                Phone = "",
                Address = "",
                Gender = 0,
                BirthDate = DateTimeOffset.UtcNow,
                StateId = 1,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow,
            }
        );

        builder.HasData(
            new User()
            {
                Id = Guid.Parse("ea8108dc-3e1d-42ab-a932-9016b22e717e"),
                UserName = "fvaras",
                Password = "fvaras",
                Rut = "15111222K",
                FirstName = "Fernando",
                LastName = "Varas",
                Email = "fdovarasc@gmail.com",
                Phone = "",
                Address = "",
                Gender = 0,
                BirthDate = DateTimeOffset.UtcNow.AddYears(-41),
                StateId = 1,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow,
            }
        );
    }
}

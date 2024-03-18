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
                Id = 1,
                UserName = "admin",
                Password = "admin",
                Rut = "19",
                FirstName = "admin",
                LastName = "",
                Email = "fdovarasc@gmail.com",
                Phone = "",
                Address = "",
                Gender = 0,
                BirthDate = DateTime.Now,
                StateId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        );
    }
}

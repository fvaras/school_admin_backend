using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_admin_api.Model;

namespace school_admin_api.Repository.Configurations;

public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
{
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
        builder.HasData(
            new Calendar()
            {
                Id = Guid.Parse("0cd91eac-3acb-4538-9377-d6be9bf5a7ec"),
                Title = "General",
                StateId = (byte)Calendar.CALENDAR_STATES.ACTIVE
            }
        );
    }
}

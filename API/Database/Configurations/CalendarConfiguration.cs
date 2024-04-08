using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_admin_api.Model;

namespace school_admin_api.Database.Configurations;

public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
{
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
        builder.HasData(
            new Calendar()
            {
                Id = 1,
                Title = "General",
                StateId = (byte)Calendar.CALENDAR_STATES.ACTIVE
            }
        );
    }
}

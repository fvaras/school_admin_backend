using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using school_admin_api.Model;

namespace school_admin_api.Database.Configurations;

public class GradeTeacherConfiguration : IEntityTypeConfiguration<GradeTeacher>
{
    public void Configure(EntityTypeBuilder<GradeTeacher> builder)
    {
        builder
            .HasKey(gt => new { gt.GradeId, gt.TeacherId });
        builder
            .HasOne(gt => gt.Grade)
            .WithMany(g => g.GradeTeachers)
            .HasForeignKey(gt => gt.GradeId);
        builder
            .HasOne(gt => gt.Teacher)
            .WithMany(t => t.GradeTeachers)
            .HasForeignKey(gt => gt.TeacherId);

    }
}
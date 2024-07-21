﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using school_admin_api.Database;

#nullable disable

namespace school_admin_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240721203328_teacher_grades_name")]
    partial class teacher_grades_name
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GuardianStudent", b =>
                {
                    b.Property<Guid>("GuardiansId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("GuardiansId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("GuardianStudent", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.Calendar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<byte>("StateId")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Calendars", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.CalendarEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid>("CalendarId")
                        .HasColumnType("uuid");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("StateId")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("CalendarEvents", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<byte>("Capacity")
                        .HasColumnType("smallint");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Grades", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.GradeTeacher", b =>
                {
                    b.Property<Guid>("GradeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<byte>("Order")
                        .HasColumnType("smallint");

                    b.HasKey("GradeId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("GradeTeachers", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.Guardian", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("StateId")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Guardians", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.Homework", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("EndsAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("StateId")
                        .HasColumnType("smallint");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Homeworks", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.Planning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Activities")
                        .HasColumnType("text");

                    b.Property<string>("Contents")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan?>("EstimatedDuration")
                        .HasColumnType("interval");

                    b.Property<string>("EvaluationPlan")
                        .HasColumnType("text");

                    b.Property<string>("ExpectedLearning")
                        .HasColumnType("text");

                    b.Property<Guid>("LastUpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Resources")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("StateId")
                        .HasColumnType("smallint");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Plannings", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.PlanningTimeBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PlanningId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TimeBlockId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TimeBlockId");

                    b.HasIndex("PlanningId", "TimeBlockId", "Date")
                        .IsUnique();

                    b.ToTable("PlanningTimeBlock");
                });

            modelBuilder.Entity("school_admin_api.Model.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Profiles", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ccd8f71e-b6a6-4b04-84cf-ee3bcea3999c"),
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = new Guid("398d52f1-0d94-40f9-8ef2-bc801c714490"),
                            Name = "Teacher"
                        },
                        new
                        {
                            Id = new Guid("521c2799-f386-4ea2-ba2f-64a81f86fd9d"),
                            Name = "Student"
                        },
                        new
                        {
                            Id = new Guid("9282b9d9-4c59-41c9-859a-58d37551fcae"),
                            Name = "Guardian"
                        });
                });

            modelBuilder.Entity("school_admin_api.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Allergies")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("GradeId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("JoiningDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("StateId")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("UserId");

                    b.ToTable("Students", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("GradeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("StateId")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.TimeBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BlockName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<byte>("Day")
                        .HasColumnType("smallint");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("interval");

                    b.Property<Guid>("GradeId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsRecess")
                        .HasColumnType("boolean");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("interval");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("TimeBlocks", "public");
                });

            modelBuilder.Entity("school_admin_api.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("StateId")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("845900f3-b438-4461-9ef0-3aa846085000"),
                            Address = "",
                            BirthDate = new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9270), new TimeSpan(0, 0, 0, 0, 0)),
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9273), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "fdovarasc@gmail.com",
                            FirstName = "admin",
                            Gender = (byte)0,
                            LastName = "",
                            Password = "admin",
                            Phone = "",
                            Rut = "19",
                            StateId = (byte)1,
                            UpdatedAt = new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9274), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("ea8108dc-3e1d-42ab-a932-9016b22e717e"),
                            Address = "",
                            BirthDate = new DateTimeOffset(new DateTime(1983, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 0, 0, 0, 0)),
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9373), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "fdovarasc@gmail.com",
                            FirstName = "Fernando",
                            Gender = (byte)0,
                            LastName = "Varas",
                            Password = "fvaras",
                            Phone = "",
                            Rut = "15111222K",
                            StateId = (byte)1,
                            UpdatedAt = new DateTimeOffset(new DateTime(2024, 7, 21, 20, 33, 28, 316, DateTimeKind.Unspecified).AddTicks(9374), new TimeSpan(0, 0, 0, 0, 0)),
                            UserName = "fvaras"
                        });
                });

            modelBuilder.Entity("school_admin_api.Model.UserProfile", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("845900f3-b438-4461-9ef0-3aa846085000"),
                            ProfileId = new Guid("ccd8f71e-b6a6-4b04-84cf-ee3bcea3999c")
                        },
                        new
                        {
                            UserId = new Guid("ea8108dc-3e1d-42ab-a932-9016b22e717e"),
                            ProfileId = new Guid("ccd8f71e-b6a6-4b04-84cf-ee3bcea3999c")
                        },
                        new
                        {
                            UserId = new Guid("ea8108dc-3e1d-42ab-a932-9016b22e717e"),
                            ProfileId = new Guid("398d52f1-0d94-40f9-8ef2-bc801c714490")
                        });
                });

            modelBuilder.Entity("GuardianStudent", b =>
                {
                    b.HasOne("school_admin_api.Model.Guardian", null)
                        .WithMany()
                        .HasForeignKey("GuardiansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_admin_api.Model.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("school_admin_api.Model.CalendarEvent", b =>
                {
                    b.HasOne("school_admin_api.Model.Calendar", "Calendar")
                        .WithMany("CalendarEvents")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calendar");
                });

            modelBuilder.Entity("school_admin_api.Model.GradeTeacher", b =>
                {
                    b.HasOne("school_admin_api.Model.Grade", "Grade")
                        .WithMany("GradeTeachers")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_admin_api.Model.Teacher", "Teacher")
                        .WithMany("GradeTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("school_admin_api.Model.Guardian", b =>
                {
                    b.HasOne("school_admin_api.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("school_admin_api.Model.Homework", b =>
                {
                    b.HasOne("school_admin_api.Model.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("school_admin_api.Model.Planning", b =>
                {
                    b.HasOne("school_admin_api.Model.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("school_admin_api.Model.PlanningTimeBlock", b =>
                {
                    b.HasOne("school_admin_api.Model.Planning", "Planning")
                        .WithMany("PlanningTimeBlocks")
                        .HasForeignKey("PlanningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_admin_api.Model.TimeBlock", "TimeBlock")
                        .WithMany("PlanningTimeBlocks")
                        .HasForeignKey("TimeBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planning");

                    b.Navigation("TimeBlock");
                });

            modelBuilder.Entity("school_admin_api.Model.Student", b =>
                {
                    b.HasOne("school_admin_api.Model.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId");

                    b.HasOne("school_admin_api.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("User");
                });

            modelBuilder.Entity("school_admin_api.Model.Subject", b =>
                {
                    b.HasOne("school_admin_api.Model.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_admin_api.Model.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("school_admin_api.Model.Teacher", b =>
                {
                    b.HasOne("school_admin_api.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("school_admin_api.Model.TimeBlock", b =>
                {
                    b.HasOne("school_admin_api.Model.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_admin_api.Model.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Grade");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("school_admin_api.Model.UserProfile", b =>
                {
                    b.HasOne("school_admin_api.Model.Profile", "Profile")
                        .WithMany("UserProfiles")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_admin_api.Model.User", "User")
                        .WithMany("UserProfiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("school_admin_api.Model.Calendar", b =>
                {
                    b.Navigation("CalendarEvents");
                });

            modelBuilder.Entity("school_admin_api.Model.Grade", b =>
                {
                    b.Navigation("GradeTeachers");
                });

            modelBuilder.Entity("school_admin_api.Model.Planning", b =>
                {
                    b.Navigation("PlanningTimeBlocks");
                });

            modelBuilder.Entity("school_admin_api.Model.Profile", b =>
                {
                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("school_admin_api.Model.Teacher", b =>
                {
                    b.Navigation("GradeTeachers");
                });

            modelBuilder.Entity("school_admin_api.Model.TimeBlock", b =>
                {
                    b.Navigation("PlanningTimeBlocks");
                });

            modelBuilder.Entity("school_admin_api.Model.User", b =>
                {
                    b.Navigation("UserProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}

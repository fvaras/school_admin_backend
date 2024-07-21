using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Services;
using school_admin_api.Database;
using school_admin_api.Database.Helpers;
using school_admin_api.Services;
using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.ConfigSettings;

namespace school_admin_api.Extensions;

public static class ServiceExtensions
{
    public static string CorsPolicyString { get; } = "CorsPolicy";

    public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerService>();

    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                // .WithExposedHeaders("X-Pagination")
                );
        });

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            string connectionString = configuration.GetConnectionString("school_db");
            // string connectionString = Environment.GetEnvironmentVariable("SchoolAdm_DB_ConnString");
            options.UseNpgsql(connectionString);
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public static void AddServices(this IServiceCollection services)
    {
        // DAL
        services.AddTransient<ConnectionsHelper>();
        services.AddScoped<IUserDAL, UserDAL>();
        services.AddScoped<IProfileDAL, ProfileDAL>();
        services.AddScoped<IStudentDAL, StudentDAL>();
        services.AddScoped<IGradeDAL, GradeDAL>();
        services.AddScoped<ITeacherDAL, TeacherDAL>();
        services.AddScoped<IGradeTeachersRepository, GradeTeachersRepository>();
        services.AddScoped<IGuardianDAL, GuardianDAL>();
        services.AddScoped<ICalendarDAL, CalendarDAL>();
        services.AddScoped<ICalendarEventDAL, CalendarEventDAL>();
        services.AddScoped<ISubjectDAL, SubjectDAL>();
        services.AddScoped<IPlanningDAL, PlanningDAL>();
        services.AddScoped<ITimeBlockDAL, TimeBlockDAL>();
        services.AddScoped<IPlanningTimeBlockDAL, PlanningTimeBlockDAL>();
        services.AddScoped<IHomeworkRepository, HomeworkRepository>();

        // Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddSingleton<IJWTService, JWTService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IGradeService, GradeService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IGuardianService, GuardianService>();
        services.AddScoped<ICalendarService, CalendarService>();
        services.AddScoped<ICalendarEventService, CalendarEventService>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IPlanningService, PlanningService>();
        services.AddScoped<ITimeBlockService, TimeBlockService>();
        services.AddScoped<IHomeworkService, HomeworkService>();
    }

    public static void ConfigureAppSettingsMapping(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TokenSettings>(configuration.GetSection("jwt"));
    }
}

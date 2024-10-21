using Amazon.CloudWatchLogs;
using Amazon.Extensions.NETCore.Setup;
using school_admin_api.Contracts.Services;
using school_admin_api.Services;
using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.ConfigSettings;
using school_admin_api.Repository;
using school_admin_api.Repository.Helpers;
using school_admin_api.Contracts.Repository;

namespace school_admin_api.Extensions;

public static class ServiceExtensions
{
    public static string CorsPolicyString { get; } = "CorsPolicy";

    public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerService>();

    public static IServiceCollection ConfigureLoggerServiceCloudWatch(this IServiceCollection services, IConfiguration configuration)
    {
        // Retrieve AWS region from environment variables or configuration
        var region = Environment.GetEnvironmentVariable("SCHOOL_ADMIN_AWS_REGION");

        if (string.IsNullOrEmpty(region))
        {
            throw new Exception("AWS region must be set in environment variables or configuration.");
        }

        var awsOptions = new AWSOptions
        {
            Region = Amazon.RegionEndpoint.GetBySystemName(region)
        };

        // When not explicitly setting credentials, the SDK will use the IAM role associated with the service (e.g., EC2, Lambda)
        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonCloudWatchLogs>();

        // Add the logging service
        services.AddSingleton<ILoggerService>(provider =>
            new LoggerServiceCloudWatch(
                provider.GetRequiredService<IAmazonCloudWatchLogs>(),
                "school-admin-log-group",
                provider.GetRequiredService<ILogger<LoggerServiceCloudWatch>>()
            ));

        return services;
    }

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
            // string connectionString = configuration.GetConnectionString("school_db");
            string connectionString = Environment.GetEnvironmentVariable("SCHOOL_ADMIN_DB_ConnString");
            options.UseNpgsql(connectionString);

        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        // Repository
        // services.AddTransient<ConnectionsHelper>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IGradeTeachersRepository, GradeTeachersRepository>();
        services.AddScoped<IGuardianRepository, GuardianRepository>();
        services.AddScoped<ICalendarRepository, CalendarRepository>();
        services.AddScoped<ICalendarEventRepository, CalendarEventRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IPlanningRepository, PlanningRepository>();
        services.AddScoped<ITimeBlockRepository, TimeBlockRepository>();
        services.AddScoped<IPlanningTimeBlockRepository, PlanningTimeBlockRepository>();
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

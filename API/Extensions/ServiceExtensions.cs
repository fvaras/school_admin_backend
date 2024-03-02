using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Services;
using school_admin_api.Database;
using school_admin_api.Database.Helpers;
using school_admin_api.Services;
using Microsoft.EntityFrameworkCore;

namespace school_admin_api.Extensions;

public static class ServiceExtensions
{
    public static string CorsPolicyString { get; } = "CorsPolicy";

    public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerService>();

    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyString, builder =>
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination")
                );
        });

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString("school_db"));
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public static void AddServices(this IServiceCollection services)
    {
        // DAL
        services.AddTransient<ConnectionsHelper>();
        services.AddScoped<IMyEntityDAL, MyEntityDAL>();

        // Services
        services.AddScoped<IMyEntityService, MyEntityService>();
    }

    public static void ConfigureAppSettingsMapping(this IServiceCollection services, IConfiguration configuration)
    {
        // services.Configure<AppSettings>(configuration.GetSection("appSettings"));
    }
}

using NLog;
using school_admin_api.Contracts.Services;
using school_admin_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// // // Logger Service
// // LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// // builder.Services.ConfigureLoggerService();
// // Configure Log Manager
#if DEBUG
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.ConfigureLoggerService();
#else
builder.Services.ConfigureLoggerServiceCloudWatch(builder.Configuration);
#endif

// CORS
builder.Services.ConfigureCors();

// .NET Cache
builder.Services.AddMemoryCache();

// EF Core
builder.Services.ConfigureSqlContext(builder.Configuration);

// Add services to the container.
builder.Services.AddServices();

// Mapping AppSettings
builder.Services.ConfigureAppSettingsMapping(builder.Configuration);

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

// Exception Handler Middleware
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// TODO: Remove me! I just exist for dev purposes
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}
// else
//     app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();
app.ConfigureCustomAuthorizationMiddleware();

app.MapControllers();

app.Run();

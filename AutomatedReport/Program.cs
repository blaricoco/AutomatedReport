using AutomatedReport;
using AutomatedReport.DataAccess;
using AutomatedReport.DataAccess.Contract;
using AutomatedReport.DataAccess.Model;
using AutomatedReport.DataAccess.Repository;
using Coravel;
using Serilog;
using System.Reflection;

var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
var projectName = Assembly.GetEntryAssembly().GetName().Name ?? "Log";

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($@"appsettings.{environment}.json", true, true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .WriteTo.File($@"{AppDomain.CurrentDomain.BaseDirectory}/Logs/{projectName}-{DateTime.Now.ToString("yyyyMMdd")}.log")
    .CreateLogger();


try
{
    Log.Information("Starting web host");

    IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureServices(services =>
    {

        services.AddScheduler();
        services.AddTransient<TestService>();
        services.AddTransient<ScheduledTask>();
        services.AddTransient<DapperContext>();
        services.AddTransient<IGenericRepository<Report>, ReportRepository>();
        services.AddTransient<IGenericRepository<ReportFrequency_>, ReportFrequencyRepository>();
        services.AddTransient<IGenericRepository<ReportSchedule>, ReportScheduleRepository>();
        services.AddTransient<IGenericRepository<ReportScheduledFrequency>, ReportScheduledFrequencyRepository>();
    })
    .Build();

    host.Services.UseScheduler(scheduler =>
    {
        scheduler.Schedule<ScheduledTask>().EveryFiveSeconds();
    });

    await host.RunAsync();

    return 0;
}

catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}

finally
{
    Log.CloseAndFlush();
}


using Serilog;
using Serilog.Formatting.Json;

namespace VendManager.BlazorUI.Services
{
    public static class AppExtension
    {
        public static void SerilogConfiguration(this IHostBuilder builder)
        {
            //builder.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
            //    .ReadFrom.Configuration(hostingContext.Configuration)
            //    .Enrich.FromLogContext()
            //    .WriteTo.Console()
            //    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
            //);

            builder.UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration.WriteTo.Console();
                loggerConfiguration.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day);
            });
        }
    }
}

using Serilog;
using Serilog.Formatting.Json;

namespace SerilogApp.Extensions;

public static class SerilogExtensions
{
    public static void AddSerilog(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog
        (
            ((context, configuration) =>
            {
                // Configure writing to console.
                configuration.WriteTo.Console();

                // Configure writing to a separate file by specifying the rollingInterval.3
                configuration.WriteTo.File
                    (new JsonFormatter(), "Logs/log.txt", rollingInterval: RollingInterval.Day);
            })
        );
    }
}
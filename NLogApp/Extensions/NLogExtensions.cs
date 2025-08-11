using NLog.Web;

namespace NLogApp.Extensions;

public static class NLogExtensions
{
    public static void AddNLogExtension(this IServiceCollection services)
    {
        // Remove Microsoft logging.
        services.AddLogging
        (loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            }
        );

        // Add NLog for logging.
        services.AddNLogWeb();
    }
}
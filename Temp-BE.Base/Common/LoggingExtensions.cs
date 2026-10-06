using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Temp_BE.Base.Common
{
    public static class LoggingExtensions
    {
        public static IHostBuilder AddCommonLogging(
            this IHostBuilder hostBuilder,
            IConfiguration configuration, string applicationName)
        {
            return hostBuilder.UseSerilog((context, logger) =>
            {
                logger.ReadFrom.Configuration(configuration).Enrich.WithProperty("ServiceName", applicationName);
            });
        }
    }
}

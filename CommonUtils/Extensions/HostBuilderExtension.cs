using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Extensions
{
    public static class HostBuilderExtension
    {
        public static IHostBuilder AddSerilogLogging(this IHostBuilder builder)
        {
            builder.ConfigureLogging((hostingContext, logging) =>
            {
                var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .CreateLogger();

                logging.AddSerilog(logger);
            });

            return builder;
        }
    }
}

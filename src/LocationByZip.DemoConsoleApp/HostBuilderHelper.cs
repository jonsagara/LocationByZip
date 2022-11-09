using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LocationByZip.DemoConsoleApp;

public static class HostBuilderHelper
{
    public static IHost BuildHost(string[] args)
    {
        return new HostBuilder()
            .ConfigureHostConfiguration(cb => ConfigureHost(cb, args))
            .ConfigureAppConfiguration((ctx, cb) => ConfigureApp(ctx, cb, args))
            .ConfigureServices(ConfigureServices)
            .ConfigureLogging(ConfigureLogging)
            .UseConsoleLifetime()
            .Build();
    }


    //
    // Private methods
    //

    private static void ConfigureHost(IConfigurationBuilder configBuilder, string[] args)
    {
        configBuilder.SetBasePath(Directory.GetCurrentDirectory());
        configBuilder.AddJsonFile("hostsettings.json", optional: true);

        if (args != null)
        {
            configBuilder.AddCommandLine(args);
        }
    }

    private static void ConfigureApp(HostBuilderContext hostContext, IConfigurationBuilder configBuilder, string[] args)
    {
        configBuilder.AddJsonFile("appsettings.json", optional: true);
        configBuilder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);

        if (args != null)
        {
            configBuilder.AddCommandLine(args);
        }
    }

    private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
    {
        //Console.WriteLine($"Environment: {hostContext.HostingEnvironment.EnvironmentName}");
        services.AddTransient<LocationService, LocationService>();
        services.AddTransient<ILocationRepository, SqlLocationRepository>();
    }

    private static void ConfigureLogging(HostBuilderContext hostContext, ILoggingBuilder loggingBuilder)
    {
        loggingBuilder.AddConsole();
    }
}

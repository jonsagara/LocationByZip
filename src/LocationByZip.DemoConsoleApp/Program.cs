using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LocationByZip.DemoConsoleApp
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            try
            {
                var builder = new HostBuilder()
                    .ConfigureHostConfiguration(
                        configHost =>
                        {
                            configHost.SetBasePath(Directory.GetCurrentDirectory());
                            configHost.AddJsonFile("hostsettings.json", optional: true);

                            if (args != null)
                            {
                                configHost.AddCommandLine(args);
                            }
                        })
                    .ConfigureAppConfiguration(
                        (hostContext, configApp) =>
                        {
                            configApp.AddJsonFile("appsettings.json", optional: true);
                            configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);

                            if (args != null)
                            {
                                configApp.AddCommandLine(args);
                            }
                        })
                    .ConfigureServices(
                        (hostContext, services) =>
                        {
                            Console.WriteLine($"Environment: {hostContext.HostingEnvironment.EnvironmentName}");
                            services.AddTransient<LocationService, LocationService>();
                            services.AddTransient<ILocationRepository, SqlLocationRepository>();
                        })
                    .ConfigureLogging(
                        (hostContext, configLogging) =>
                        {
                            configLogging.AddConsole();
                        })
                    .UseConsoleLifetime();

                var host = builder.Build();

                using (var serviceScope = host.Services.CreateScope())
                {
                    var services = serviceScope.ServiceProvider;

                    try
                    {
                        var locationSvc = services.GetRequiredService<LocationService>();

                        // Location by ZIP Code
                        Console.WriteLine("=== Location by ZIP Code ===");
                        var location = await locationSvc.GetByZipCodeAsync("93275");
                        if (location is object)
                        {
                            DisplayLocation(location);
                        }


                        // Location(s) by City/State
                        Console.WriteLine();
                        Console.WriteLine("=== Location(s) by City/State ===");

                        var locationsByCityState = await locationSvc.GetByCityStateAsync("Tulare", "CA");
                        foreach (var loc in locationsByCityState)
                        {
                            DisplayLocation(loc);
                        }


                        // Location(s) in Radius
                        Console.WriteLine();
                        Console.WriteLine("=== Location(s) in Radius ===");

                        var locsationsInRadius = await locationSvc.GetLocationsInRadiusAsync("93401", 10.0);
                        foreach (Location locInRad in locsationsInRadius)
                        {
                            DisplayLocation(locInRad);
                        }


                        //	Distance between two locations.
                        Console.WriteLine();
                        Console.WriteLine("=== Distance between two ZIP Codes ===");

                        var distance = await locationSvc.GetDistanceBetweenLocationsAsync("93401", "93446");
                        Console.WriteLine("93401 is {0:F1} miles from 93446", distance);
                        Console.WriteLine();


                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        Console.Error.WriteLine($"Unhandled exception: {ex}");
                        logger.LogError(ex, "Unhandled exception");
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unhandled exception in Main: {ex}");
                return 1;
            }
        }

        static void DisplayLocation(Location location)
        {
            Console.WriteLine(location);
            Console.WriteLine();
        }
    }
}

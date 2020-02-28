using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LocationByZip.DemoConsoleApp
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            try
            {
                // Build the generic host.
                var host = HostBuilderHelper.BuildHost(args);

                // Demo the location service.
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
                            Console.WriteLine(location);
                        }

                        // Location(s) by City/State
                        Console.WriteLine();
                        Console.WriteLine("=== Location(s) by City/State ===");

                        var locationsByCityState = await locationSvc.GetByCityStateAsync("Tulare", "CA");
                        foreach (var locByCityState in locationsByCityState)
                        {
                            Console.WriteLine(locByCityState);
                        }

                        // Location(s) in Radius
                        Console.WriteLine();
                        Console.WriteLine("=== Location(s) in Radius ===");

                        var locsationsInRadius = await locationSvc.GetLocationsInRadiusAsync("93401", 10.0);
                        foreach (var locInRad in locsationsInRadius)
                        {
                            Console.WriteLine(locInRad);
                        }

                        //	Distance between two locations.
                        Console.WriteLine();
                        Console.WriteLine("=== Distance between two ZIP Codes ===");

                        var distance = await locationSvc.GetDistanceBetweenLocationsAsync("93401", "93446");
                        Console.WriteLine($"93401 is {distance:F1} miles from 93446");
                        Console.WriteLine();
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
    }
}

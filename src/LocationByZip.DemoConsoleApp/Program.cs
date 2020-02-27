using System;

namespace LocationByZip.DemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var locationSvc = new LocationService();

            // Location by ZIP Code
            Console.WriteLine("=== Location by ZIP Code ===");
            Location location = locationSvc.GetByZipCode("93275");
            if (location != null)
            {
                DisplayLocation(location);
            }


            // Location(s) by City/State
            Console.WriteLine();
            Console.WriteLine("=== Location(s) by City/State ===");

            var locationsByCityState = locationSvc.GetByCityState("Tulare", "CA");
            foreach (var loc in locationsByCityState)
            {
                DisplayLocation(loc);
            }


            // Location(s) in Radius
            Console.WriteLine();
            Console.WriteLine("=== Location(s) in Radius ===");

            var locsationsInRadius = locationSvc.GetLocationsInRadius("93401", 10.0);
            foreach (Location locInRad in locsationsInRadius)
            {
                DisplayLocation(locInRad);
            }


            //	Distance between two locations.
            Console.WriteLine();
            Console.WriteLine("=== Distance between two ZIP Codes ===");

            var distance = locationSvc.GetDistanceBetweenLocations("93401", "93446");
            Console.WriteLine("93401 is {0:F1} miles from 93446", distance);
            Console.WriteLine();


            Console.ReadLine();
        }

        static void DisplayLocation(Location location)
        {
            Console.WriteLine(location);
            Console.WriteLine();
        }
    }
}

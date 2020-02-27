using System;
using System.Collections.Generic;

using LocationByZip;

namespace LocationByZip.DemoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ILocationService locationSvc = new LocationService();

            // Location by ZIP Code
            Console.WriteLine("=== Location by ZIP Code ===");
            Location location = locationSvc.GetByZipCode("93275");
            if (location != null)
            {
                DisplayLocation(location);
            }


            // Location(s) by City/State
            Console.WriteLine("{0}=== Location(s) by City/State ===", Environment.NewLine);
            IEnumerable<Location> locs = locationSvc.GetByCityState("Tulare", "CA");
            foreach (Location loc in locs)
            {
                DisplayLocation(loc);
            }


            // Location(s) in Radius
            Console.WriteLine("{0}=== Location(s) in Radius ===", Environment.NewLine);
            IEnumerable<LocationInRadius> locsInRadius = locationSvc.GetLocationsInRadius("93401", 10.0);
            foreach (Location locInRad in locsInRadius)
            {
                DisplayLocation(locInRad);
            }


            //	Distance between two locations.
            Console.WriteLine("{0}=== Distance between two ZIP Codes ===", Environment.NewLine);
            double distance = locationSvc.GetDistanceBetweenLocations("93401", "93446");
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

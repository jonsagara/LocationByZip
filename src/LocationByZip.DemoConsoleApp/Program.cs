using System;
using System.Collections.Generic;

using LocationByZip;

namespace LocationByZip.DemoConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//	Location by ZIP Code.
			Location location = ZipCodeUtil.LookupByZipCode("93275");
			if (location != null)
			{
				Console.WriteLine(location);
				Console.WriteLine();
			}


			//	Location(s) by City/State.
			IList<Location> locs = ZipCodeUtil.LookupByCityState("Tulare", "CA");
			foreach (Location loc in locs)
			{
				Console.WriteLine(loc);
				Console.WriteLine();
			}


			//	Distance between two locations.
			Location roseville = ZipCodeUtil.LookupByZipCode("95747");
			Location sacramento = ZipCodeUtil.LookupByZipCode("95814");
			Console.WriteLine("{0} is {1:F1} miles from {2}", roseville.City, roseville.DistanceFrom(sacramento), sacramento.City);
			Console.WriteLine();


			//	Other Locations within an X-mile radius of a specific location.
			IList<LocationInRadius> locsInRadius = roseville.LocationsWithinRadius(5.0);
			foreach (Location locInRad in locsInRadius)
			{
				Console.WriteLine(locInRad);
				Console.WriteLine();
			}


			Console.ReadLine();
		}
	}
}

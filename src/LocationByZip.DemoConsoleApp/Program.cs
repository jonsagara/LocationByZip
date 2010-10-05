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
			}


			//	Location(s) by City/State.
			IList<Location> locs = ZipCodeUtil.LookupByCityState("Tulare", "CA");
			foreach (Location loc in locs)
			{
				Console.WriteLine(loc);
			}


			//	Distance between two locations.
			Location sf = ZipCodeUtil.LookupByZipCode("94175");
			Location la = ZipCodeUtil.LookupByZipCode("90185");
			Double dDistance = sf.DistanceFrom(la);
			Console.WriteLine("{0} is {1} miles from {2}", sf.City, dDistance, la.City);


			//	Other Locations within an X-mile radius of a specific location.
			IList<LocationInRadius> locsInRadius = sf.LocationsWithinRadius(5.0);
			foreach (Location locInRad in locsInRadius)
			{
				Console.WriteLine(locInRad);
			}


			Console.ReadLine();
		}
	}
}

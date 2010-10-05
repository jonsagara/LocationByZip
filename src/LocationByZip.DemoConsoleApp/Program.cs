using System;
using System.Collections.Generic;

using SagaraSoftware.ZipCodeUtil;

namespace LocationByZip.DemoConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//	Location by ZIP Code.
			Location location = ZipCodeUtil.LookupByZipCode("93275");
			if (location != null)
				Console.WriteLine(location.ToString());

			//	Location(s) by City/State.
			IList<Location> locs = ZipCodeUtil.LookupByCityState("Tulare", "CA");
			if (locs != null && locs.Count > 0)
			{
				foreach (Location loc in locs)
				{
					Console.WriteLine(loc.ToString());
				}
			}

			//	Location by City/State/Zip
			location = ZipCodeUtil.LookupByCityStateZip("Tulare", "CA", "93275");
			if (location != null)
				Console.WriteLine(location.ToString());

			//	Distance between two locations.
			Location sf = ZipCodeUtil.LookupByZipCode("94175");
			Location la = ZipCodeUtil.LookupByZipCode("90185");
			Double dDistance = sf.DistanceFrom(la);
			Console.WriteLine("{0} is {1} miles from {2}", sf.City, dDistance, la.City);

			//	Other Locations within an X-mile radius of a specific location.
			locs = sf.LocationsWithinRadius(5.0);
			if (null != locs && locs.Count > 0)
			{
				foreach (Location loc in locs)
				{
					Console.WriteLine(loc.ToString());
				}
			}


			Console.ReadLine();
		}
	}
}

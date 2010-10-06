using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationByZip.UnitTests.Fakes
{
	public class FakeLocationRepository : ILocationRepository
	{
		private List<Location> Locations = new List<Location>();

		public FakeLocationRepository()
		{
			Locations.Add(new Location { ZipCode = "95814", Latitude = 38.579055, Longitude = -121.480905, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
		}


		//
		// ILocationRepository Methods
		//

		public Location GetByZipCode(string zipCode)
		{
			return Locations
				.Where(loc => loc.ZipCode.Equals(zipCode, StringComparison.OrdinalIgnoreCase))
				.SingleOrDefault();
		}

		public IEnumerable<Location> GetByCityState(string city, string state)
		{
			return Locations
				.Where(loc => loc.City.Equals(city, StringComparison.OrdinalIgnoreCase) && loc.State.Equals(state, StringComparison.OrdinalIgnoreCase));
		}
	}
}

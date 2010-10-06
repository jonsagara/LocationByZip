using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationByZip
{
	public interface ILocationService
	{
		Location GetByZipCode(string zipCode);
		IEnumerable<Location> GetByCityState(string city, string state);
		IEnumerable<LocationInRadius> GetLocationsInRadius(string zipCode, double radius);
	}
}

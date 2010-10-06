using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationByZip
{
	public interface ILocationRepository
	{
		Location GetByZipCode(string zipCode);
		IEnumerable<Location> GetByCityState(string city, string state);
	}
}

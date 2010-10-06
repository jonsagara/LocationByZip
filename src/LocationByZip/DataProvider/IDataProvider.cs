using System;
using System.Collections.Generic;
using System.Configuration;

namespace LocationByZip.DataProvider
{
	/// <summary>
	/// Defines methods common to all data providers.  An instance of this interface is used to 
	///  interact with the ZIP Codes database.  
	/// </summary>
	public interface IDataProvider
	{
		Location DoLookupByZipCode(string zipCode);
		IList<Location> DoLookupByCityState(string city, string state);
		IList<LocationInRadius> GetLocationsWithinRadius(Location pointOfReference, RadiusBox bounds);
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

using LocationByZip.DataProvider;

namespace LocationByZip
{
	/// <summary>
	/// Summary description for Radius.
	/// </summary>
	public class Radius
	{
		/// <summary>
		/// Return a list of Locations that fall within the radius of the specified Location.
		/// </summary>
		/// <param name="location">The Location around which to search.</param>
		/// <param name="radius">Search radius in miles.</param>
		/// <returns></returns>
		public static IList<LocationInRadius> LocationsWithinRadius(Location location, double radius)
		{
			VerifyLocation(location);
			VerifyRadius(radius);

			RadiusBox radBox = RadiusBox.Create(location, radius);

			return DataProviderFactory.Create().GetLocationsWithinRadius(location, radBox);
		}


		//
		// Helpers
		//

		private static void VerifyLocation(Location location)
		{
			Debug.Assert(location != null);
			Debug.Assert(location.Latitude != double.MinValue);
			Debug.Assert(location.Longitude != double.MinValue);

			if (location == null)
				throw new ArgumentNullException("inLocation", "Null location passed in.");
			if (location.Latitude == double.MinValue)
				throw new ArgumentException("inLocation.Latitude", string.Format("The database does not contain latitude information for {0}, {1}.", location.City, location.State));
			if (location.Longitude == double.MinValue)
				throw new ArgumentException("inLocation.Longitude", string.Format("The database does not contain longitude information for {0}, {1}.", location.City, location.State));
		}

		private static void VerifyRadius(double radius)
		{
			Debug.Assert(radius > 0.0);

			if (radius <= 0.0)
				throw new ArgumentOutOfRangeException("inRadius", radius, "Invalid value for radius passed in.");
		}
	}
}

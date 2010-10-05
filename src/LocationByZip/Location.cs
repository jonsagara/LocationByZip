using System;
using System.Collections.Generic;
using System.Text;

namespace LocationByZip
{
	/// <summary>
	/// A Location is represented by a City, State, ZIP Code, County, Latitude, Longitude, and ZIP 
	///  Class.  This just so happens to correspond to the columns of the ZIP_CODES table.
	/// </summary>
	public class Location
	{
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string County { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string ZipClass { get; set; }


		public double DistanceFrom(Location inRemoteLocation)
		{
			return Distance.GetDistance(this, inRemoteLocation);
		}


		public IList<LocationInRadius> LocationsWithinRadius(double inRadius)
		{
			return Radius.LocationsWithinRadius(this, inRadius);
		}


		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			str.AppendFormat("Location: {0}, {1} {2} in {3} County{4}", City, State, ZipCode, County, Environment.NewLine);
			str.AppendFormat("\tLatitude:\t{0}{1}", Latitude, Environment.NewLine);
			str.AppendFormat("\tLongitude:\t{0}{1}", Longitude, Environment.NewLine);
			str.AppendFormat("\tZip Class:\t{0}", ZipClass);

			return str.ToString();
		}
	}
}

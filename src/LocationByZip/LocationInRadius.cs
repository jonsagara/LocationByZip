using System.Text;
using System;

namespace LocationByZip
{
	public class LocationInRadius : Location
	{
		public double DistanceToCenter { get; set; }


		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			str.AppendFormat("Location: {0}, {1} {2} in {3} County{4}", City, State, ZipCode, County, Environment.NewLine);
			str.AppendFormat("\tLatitude:\t{0}{1}", Latitude, Environment.NewLine);
			str.AppendFormat("\tLongitude:\t{0}{1}", Longitude, Environment.NewLine);
			str.AppendFormat("\tZip Class:\t{0}{1}", ZipClass, Environment.NewLine);
			str.AppendFormat("\tDistance to original location:\t{0:F1} miles", DistanceToCenter);

			return str.ToString();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationByZip
{
	public class LocationInRadius : Location
	{
		public double DistanceToCenter { get; set; }


		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			str.AppendFormat("Location: {0}, {1} {2} in {3} County\n", City, State, ZipCode, County);
			str.AppendFormat("\tLatitude:\t{0}\n", Latitude);
			str.AppendFormat("\tLongitude:\t{0}\n", Longitude);
			str.AppendFormat("\tZip Class:\t{0}\n", ZipClass);
			str.AppendFormat("\tDistance to original location:\t{0}\n", DistanceToCenter);

			return str.ToString();
		}
	}
}

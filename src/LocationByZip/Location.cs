using System;
using System.Text;

namespace LocationByZip
{
	/// <summary>
	/// A Location is represented by a City, State, ZIP Code, County, Latitude, Longitude, and ZIP 
	///  Class.  This just so happens to correspond to the columns of the ZipCodes table.
	/// </summary>
	public class Location
	{
		//
		// Instance Properties
		//

		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string County { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string ZipClass { get; set; }


		//
		// Instance Methods
		//

		public double DistanceFrom(Location remoteLocation)
		{
			Verify(this);
			Verify(remoteLocation);

			return GetDistanceBetweenLocations(this, remoteLocation);
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

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			Location other = obj as Location;
			if (other == null)
			{
				return false;
			}

			return ZipCode.Equals(other.ZipCode, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode()
		{
			unchecked // Overflow is fine; just wrap.
			{
				int hash = 17;

				if (ZipCode != null)
				{
					hash = hash * 23 + ZipCode.GetHashCode();
				}

				return hash;
			}
		}


		//
		// Helpers
		//

		internal double GetDistanceBetweenLocations(Location loc1, Location loc2)
		{
			return Haversine(loc1, loc2);
		}

		/// <summary>
		/// Calculates the distance between two points on the surface of the earth.
		/// </summary>
		/// <param name="loc1"></param>
		/// <param name="loc2"></param>
		/// <returns></returns>
		private double Haversine(Location loc1, Location loc2)
		{
			/*
				The Haversine formula according to Dr. Math.
				http://mathforum.org/library/drmath/view/51879.html
				
				dlon = lon2 - lon1
				dlat = lat2 - lat1
				a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2
				c = 2 * atan2(sqrt(a), sqrt(1-a)) 
				d = R * c
				
				Where
					* dlon is the change in longitude
					* dlat is the change in latitude
					* c is the great circle distance in Radians.
					* R is the radius of a spherical Earth.
					* The locations of the two points in spherical coordinates (longitude and 
						latitude) are lon1,lat1 and lon2, lat2.
			*/
			double dDistance = double.MinValue;
			double dLat1InRad = loc1.Latitude * (Math.PI / 180.0);
			double dLong1InRad = loc1.Longitude * (Math.PI / 180.0);
			double dLat2InRad = loc2.Latitude * (Math.PI / 180.0);
			double dLong2InRad = loc2.Longitude * (Math.PI / 180.0);

			double dLongitude = dLong2InRad - dLong1InRad;
			double dLatitude = dLat2InRad - dLat1InRad;

			// Intermediate result a.
			double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) + Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) * Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

			// Intermediate result c (great circle distance in Radians).
			double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

			// Distance.
			dDistance = Globals.EarthRadiusMiles * c;

			return dDistance;
		}

		internal void Verify()
		{
			Verify(this);
		}

		internal static void Verify(Location location)
		{
			if (location == null)
			{
				throw new ArgumentNullException("location");
			}

			if (location.Latitude == double.MinValue)
			{
				throw new ArgumentException("inLoc1.Latitude", string.Format("The database does not contain latitude information for {0}, {1}.", location.City, location.State));
			}
			
			if (location.Longitude == double.MinValue)
			{
				throw new ArgumentException("inLoc1.Longitude", string.Format("The database does not contain longitude information for {0}, {1}.", location.City, location.State));
			}
		}

		private void VerifyRadius(double radius)
		{
			if (radius <= 0.0)
			{
				throw new ArgumentOutOfRangeException("inRadius", radius, "Invalid value for radius passed in.");
			}
		}


		//
		// Operator Overloads
		//

		public static bool operator ==(Location a, Location b)
		{
			// If both are null, or both are the same instance, return true.
			if (object.ReferenceEquals(a, b))
			{
				return true;
			}

			// If one is null, but not both, return false.
			// Cast to object is necessary, else we will get a StackOverflowException
			//  due to repeatedly calling this method.
			if ((object)a == null || (object)b == null)
			{
				return false;
			}

			return a.Equals(b);
		}

		public static bool operator !=(Location a, Location b)
		{
			return !(a == b);
		}
	}
}

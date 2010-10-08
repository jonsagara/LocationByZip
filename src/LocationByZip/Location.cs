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

			return Haversine.CalculateDistance(this, remoteLocation);
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

using System;
using System.Text;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// A Location is represented by a City, State, ZIP Code, County, Latitude, Longitude, and ZIP 
	///  Class.  This just so happens to correspond to the columns of the ZIP_CODES table.
	/// </summary>
	public class Location
	{
		/// <summary>
		/// Default constructor.  Does nothing.
		/// </summary>
		public Location()
		{
		}


		public String City
		{
			get
			{
				return _strCity;
			}
			set
			{
				_strCity = value;
			}
		}

		public String State
		{
			get
			{
				return _strState;
			}
			set
			{
				_strState = value;
			}
		}

		public String ZipCode
		{
			get
			{
				return _strZipCode;
			}
			set
			{
				_strZipCode = value;
			}
		}

		public String County
		{
			get
			{
				return _strCounty;
			}
			set
			{
				_strCounty = value;
			}
		}

		public Double Latitude
		{
			get
			{
				return _dLatitude;
			}
			set
			{
				_dLatitude = value;
			}
		}

		public Double Longitude
		{
			get
			{
				return _dLongitude;
			}
			set
			{
				_dLongitude = value;
			}
		}

		public String ZipClass
		{
			get
			{
				return _strZipClass;
			}
			set
			{
				_strZipClass = value;
			}
		}


		public Double DistanceFrom(Location inRemoteLocation)
		{
			return Distance.GetDistance(this, inRemoteLocation);
		}


		public Location[] LocationsWithinRadius(Double inRadius)
		{
			return Radius.LocationsWithinRadius(this, inRadius);
		}


		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			str.AppendFormat("Location: {0}, {1} {2} in {3} County\n", City, State, ZipCode, County);
			str.AppendFormat("\tLatitude:\t{0}\n", Latitude);
			str.AppendFormat("\tLongitude:\t{0}\n", Longitude);
			str.AppendFormat("\tZip Class:\t{0}\n", ZipClass);

			return str.ToString();
		}


		private string _strCity;
		private string _strState;
		private string _strZipCode;
		private string _strCounty;
		private double _dLatitude;
		private double _dLongitude;
		private string _strZipClass;
	}


	public class LocationInRadius : Location
	{
		public LocationInRadius()
			: base()
		{
			DistanceToCenter = Double.MinValue;
		}


		public Double DistanceToCenter
		{
			get
			{
				return _dDistToCenter;
			}
			set
			{
				_dDistToCenter = value;
			}
		}


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


		private double _dDistToCenter;
	}
}

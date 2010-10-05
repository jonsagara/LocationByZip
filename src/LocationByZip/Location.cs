#region FILE HEADER
/// <project>ZipCodeUtil</project>
/// <assembly>SagaraSoftware.ZipCodeUtil.dll</assembly>
/// <filename>Location.cs</filename>
/// <creator>Jon Sagara</creator>
/// <description>
/// Contains the Location and LocationInRadius classes.
/// </description>
/// <copyright>
/// Copyright (c) 2004 Sagara Software.  All rights reserved.
/// </copyright>
/// <disclaimer>
/// This file is provided "as is" with no expressed or implied warranty.  The author accepts no 
///  liability for any damage/loss of business that this product may cause.
/// </disclaimer>
/// <history>
///	<change date="12/29/2004" changedby="Jon Sagara">File created.</changed>
/// </history>
#endregion

using System;
using System.Diagnostics;
using System.Text;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// A Location is represented by a City, State, ZIP Code, County, Latitude, Longitude, and ZIP 
	///  Class.  This just so happens to correspond to the columns of the ZIP_CODES table.
	/// </summary>
	public class Location
	{
		#region CONSTRUCTORS
		/// <summary>
		/// Default constructor.  Does nothing.
		/// </summary>
		public Location ()
		{
		}
		#endregion


		#region PROPERTIES
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
		#endregion


		#region METHODS
		public Double DistanceFrom (Location inRemoteLocation)
		{
			return Distance.GetDistance (this, inRemoteLocation);
		}


		public Location[] LocationsWithinRadius (Double inRadius)
		{
			return Radius.LocationsWithinRadius (this, inRadius);
		}


		public override string ToString ()
		{
			StringBuilder str = new StringBuilder ();

			str.AppendFormat ("Location: {0}, {1} {2} in {3} County\n", City, State, ZipCode, County);
			str.AppendFormat ("\tLatitude:\t{0}\n", Latitude);
			str.AppendFormat ("\tLongitude:\t{0}\n", Longitude);
			str.AppendFormat ("\tZip Class:\t{0}\n", ZipClass);

			return str.ToString ();
		}

		#endregion


		#region MEMBER DATA
		private string _strCity;
		private string _strState;
		private string _strZipCode;
		private string _strCounty;
		private double _dLatitude;
		private double _dLongitude;
		private string _strZipClass;
		#endregion
	}


	public class LocationInRadius : Location
	{
		#region CONSTRUCTOR
		public LocationInRadius () : base ()
		{
			DistanceToCenter = Double.MinValue;
		}
		#endregion


		#region PROPERTIES
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
		#endregion


		#region METHODS
		public override string ToString ()
		{
			StringBuilder str = new StringBuilder ();

			str.AppendFormat ("Location: {0}, {1} {2} in {3} County\n", City, State, ZipCode, County);
			str.AppendFormat ("\tLatitude:\t{0}\n", Latitude);
			str.AppendFormat ("\tLongitude:\t{0}\n", Longitude);
			str.AppendFormat ("\tZip Class:\t{0}\n", ZipClass);
			str.AppendFormat ("\tDistance to original location:\t{0}\n", DistanceToCenter);

			return str.ToString ();
		}
		#endregion


		#region MEMBER DATA 
		private double _dDistToCenter;
		#endregion
	}
}

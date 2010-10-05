#region FILE HEADER
/// <project>ZipCodeUtil</project>
/// <assembly>SagaraSoftware.ZipCodeUtil.dll</assembly>
/// <filename>Distance.cs</filename>
/// <creator>Jon Sagara</creator>
/// <description>
/// Contains the Distance class.
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

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// The Distance class takes two <see cref="SagaraSoftware.ZipCodeUtil.Location" /> objects and
	///  uses their Latitude and Longitude to determine the distance between them.  Uses the
	///  Haversine formula.
	/// </summary>
	public class Distance
	{
		#region CLASS METHODS
		/// <summary>
		/// Returns the distance in miles between two locations, calculated using the Haversine
		///  forumula.
		/// </summary>
		/// <param name="inLoc1"></param>
		/// <param name="inLoc2"></param>
		/// <returns></returns>
		public static Double GetDistance (Location inLoc1, Location inLoc2)
		{
			Debug.Assert (null != inLoc1);
			Debug.Assert (null != inLoc2);

			if (null == inLoc1)
				throw new ArgumentNullException ("inLoc1", "Null location passed in.");
			if (null == inLoc2)
				throw new ArgumentNullException ("inLoc2", "Null location passed in.");

			Debug.Assert (Double.MinValue != inLoc1.Latitude);
			Debug.Assert (Double.MinValue != inLoc1.Longitude);
			Debug.Assert (Double.MinValue != inLoc2.Latitude);
			Debug.Assert (Double.MinValue != inLoc2.Longitude);

			if (Double.MinValue == inLoc1.Latitude)
				throw new ArgumentException ("inLoc1.Latitude", string.Format ("The database does not contain latitude information for {0}, {1}.", inLoc1.City, inLoc1.State));
			if (Double.MinValue == inLoc1.Longitude)
				throw new ArgumentException ("inLoc1.Longitude", string.Format ("The database does not contain longitude information for {0}, {1}.", inLoc1.City, inLoc1.State));
			if (Double.MinValue == inLoc2.Latitude)
				throw new ArgumentException ("inLoc2.Latitude", string.Format ("The database does not contain latitude information for {0}, {1}.", inLoc2.City, inLoc2.State));
			if (Double.MinValue == inLoc2.Longitude)
				throw new ArgumentException ("inLoc2.Longitude", string.Format ("The database does not contain longitude information for {0}, {1}.", inLoc2.City, inLoc2.State));

			return Haversine (inLoc1, inLoc2);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="inLoc1"></param>
		/// <param name="inLoc2"></param>
		/// <returns></returns>
		private static double Haversine (Location inLoc1, Location inLoc2)
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
			double dDistance = Double.MinValue;
			double dLat1InRad = inLoc1.Latitude * (Math.PI / 180.0);
			double dLong1InRad = inLoc1.Longitude * (Math.PI / 180.0);
			double dLat2InRad = inLoc2.Latitude * (Math.PI / 180.0);
			double dLong2InRad = inLoc2.Longitude * (Math.PI / 180.0);

			double dLongitude = dLong2InRad - dLong1InRad;
			double dLatitude = dLat2InRad - dLat1InRad;

			// Intermediate result a.
			double a = Math.Pow (Math.Sin (dLatitude / 2.0), 2.0) + Math.Cos (dLat1InRad) * Math.Cos (dLat2InRad) * Math.Pow (Math.Sin (dLongitude / 2.0), 2.0);

			// Intermediate result c (great circle distance in Radians).
			double c = 2.0 * Math.Atan2 (Math.Sqrt (a), Math.Sqrt (1.0 - a));

			// Distance.
			dDistance = Globals.kEarthRadiusMiles * c;

			return dDistance;
		}
		#endregion
	}
}

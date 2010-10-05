#region FILE HEADER
/// <project>ZipCodeUtil</project>
/// <assembly>SagaraSoftware.ZipCodeUtil.dll</assembly>
/// <filename>AccessProvider.cs</filename>
/// <creator>Jon Sagara</creator>
/// <description>
/// Contains the AccessProvider class, which is used to read data from MS Access. 
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
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// AccessProvider implements the IDataProvider interface, interacting with an MS Access 
	/// database.
	/// </summary>
	public class AccessProvider : IDataProvider
	{
		#region CONSTRUCTORS
		/// <summary>
		/// Default constructor.  Does nothing.
		/// </summary>
		public AccessProvider ()
		{
		}
		#endregion


		#region IDataProvider Members


		/// <summary>
		/// Look up a <see cref="SagaraSoftware.ZipCodeUtil.Location" /> by ZIP Code.  If Latitude
		///  or Longitude are NULL, they are set to Double.MinValue.
		/// </summary>
		/// <param name="inZipCode">ZIP Code to lookup.</param>
		/// <returns><see cref="SagaraSoftware.ZipCodeUtil.Location" /> of the ZIP Code.</returns>
		public Location DoLookupByZipCode (string inZipCode)
		{
			OleDbConnection oleConn = null;
			OleDbCommand oleCmd = null;
			OleDbDataReader oleReader = null;
			Location loc = null;
			string strConnString = ConfigurationSettings.AppSettings["ZipCodeConnString"];
			StringBuilder sql = new StringBuilder ();

			if (null == strConnString || string.Empty == strConnString)
				throw new ApplicationException ("You must provide a connection string for your MS Access database.");

			sql.Append ("SELECT * FROM ZIP_CODES WHERE ZIP = ?");

			oleConn = new OleDbConnection (strConnString);
			oleCmd = new OleDbCommand (sql.ToString (), oleConn);
			oleCmd.Parameters.Add (new OleDbParameter ("ZIP", inZipCode));
			oleConn.Open ();
			
			try
			{
				oleReader = oleCmd.ExecuteReader ();

				if (oleReader.Read ())
				{
					loc = new Location ();

					loc.City = Convert.ToString (oleReader["CITY"]);
					loc.State = Convert.ToString (oleReader["STATE"]);
					loc.ZipCode = inZipCode;
					loc.County = Convert.ToString (oleReader["COUNTY"]);
					loc.Latitude = (DBNull.Value == oleReader["LATITUDE"]) ? Double.MinValue : Double.Parse (Convert.ToString (oleReader["LATITUDE"]));
					loc.Longitude = (DBNull.Value == oleReader["LONGITUDE"]) ? Double.MinValue : Double.Parse (Convert.ToString (oleReader["LONGITUDE"]));
					loc.ZipClass = Convert.ToString (oleReader["ZIP_CLASS"]);
				}
			}
			catch (Exception e)
			{
				throw new ApplicationException ("Error getting data from database", e);
			}
			finally
			{
				if (null != oleReader)
					oleReader.Close ();
				if (null != oleConn)
					oleConn.Close ();
			}

			return loc;
		}


		/// <summary>
		/// Lookup one or more <see cref="SagaraSoftware.ZipCodeUtil.Location" />s by City/State.
		///  In the database, some cities are represented by more than one ZIP Code.
		/// </summary>
		/// <param name="inCity">Name of the City.</param>
		/// <param name="inState">Name of the State.</param>
		/// <returns>An array of <see cref="SagaraSoftware.ZipCodeUtil.Location" /> objects whose City/State matches the input City/State.</returns>
		public Location[] DoLookupByCityState (string inCity, string inState)
		{
			OleDbConnection oleConn = null;
			OleDbCommand oleCmd = null;
			OleDbDataReader oleReader = null;
			ArrayList locs = new ArrayList ();
			string strConnString = ConfigurationSettings.AppSettings["ZipCodeConnString"];
			StringBuilder sql = new StringBuilder ();

			if (null == strConnString || string.Empty == strConnString)
				throw new ApplicationException ("You must provide a connection string for your MS Access database.");

			sql.Append ("SELECT * FROM ZIP_CODES WHERE CITY = ? AND STATE = ? ORDER BY ZIP");

			oleConn = new OleDbConnection (strConnString);
			oleCmd = new OleDbCommand (sql.ToString (), oleConn);
			oleCmd.Parameters.Add (new OleDbParameter ("CITY", inCity));
			oleCmd.Parameters.Add (new OleDbParameter ("STATE", inState));
			oleConn.Open ();
			
			try
			{
				oleReader = oleCmd.ExecuteReader ();
				string jon = oleCmd.CommandText;

				while (oleReader.Read ())
				{
					Location loc = new Location ();

					loc.City = Convert.ToString (oleReader["CITY"]);
					loc.State = Convert.ToString (oleReader["STATE"]);
					loc.ZipCode = Convert.ToString (oleReader["ZIP"]);
					loc.County = Convert.ToString (oleReader["COUNTY"]);
					loc.Latitude = Double.Parse (Convert.ToString (oleReader["LATITUDE"]));
					loc.Longitude = Double.Parse (Convert.ToString (oleReader["LONGITUDE"]));
					loc.ZipClass = Convert.ToString (oleReader["ZIP_CLASS"]);

					locs.Add (loc);
				}
			}
			catch (Exception e)
			{
				throw new ApplicationException ("Error getting data from database", e);
			}
			finally
			{
				if (null != oleReader)
					oleReader.Close ();
				if (null != oleConn)
					oleConn.Close ();
			}

			return (Location[]) locs.ToArray (typeof (Location));
		}


		/// <summary>
		/// Finds all <see cref="SagaraSoftware.ZipCodeUtil.LocationInRadius" />es within X miles
		///  of inRefLoc.
		/// </summary>
		/// <remarks>
		/// To speed the calculation, this method finds all areas within a square area of dimension
		///  (2*Radius)x(2*Radius).  Any city with a Lat/Lon pair that falls within this square is
		///  returned.  However, only those cities whose distance is less than or equal to Radius
		///  miles from inRefLoc are returned.  This has the unfortunate side effect of selecting
		///  from ~22% more area than is necessary.
		/// </remarks>
		/// <param name="inRefLoc">The central location from which we are trying to find other locations within the specified radius.</param>
		/// <param name="inBounds">A class containing the "box" that encloses inRefLoc.  Used to approximate a circle of Radius R centered around the point inRefLoc.</param>
		/// <returns>0 or more <see cref="SagaraSoftware.ZipCodeUtil.LocationInRadius" />es that are
		///  within Radius miles of inRefLoc.</returns>
		public LocationInRadius[] GetLocationsWithinRadius (Location inRefLoc, RadiusBox inBounds)
		{
			OleDbConnection oleConn = null;
			OleDbCommand oleCmd = null;
			OleDbDataReader oleReader = null;
			ArrayList locs = new ArrayList ();
			string strConnString = ConfigurationSettings.AppSettings["ZipCodeConnString"];
			StringBuilder sql = new StringBuilder ();

			if (null == strConnString || string.Empty == strConnString)
				throw new ApplicationException ("You must provide a connection string for your MS Access database.");

			sql.Append ("SELECT * FROM ZIP_CODES WHERE ");
			sql.Append ("IIf(ISNULL(LATITUDE),999.0,CDbl(LATITUDE)) >= ? AND ");
			sql.Append ("IIf(ISNULL(LATITUDE),999.0,CDbl(LATITUDE)) <= ? AND ");
			sql.Append ("IIf(ISNULL(LONGITUDE),999.0,CDbl(LONGITUDE)) >= ? AND ");
			sql.Append ("IIf(ISNULL(LONGITUDE),999.0,CDbl(LONGITUDE)) <= ? ");
			sql.Append ("ORDER BY CITY, STATE, ZIP");

			oleConn = new OleDbConnection (strConnString);
			oleCmd = new OleDbCommand (sql.ToString (), oleConn);
			oleCmd.Parameters.Add (new OleDbParameter ("SouthLat", inBounds.BottomLine));
			oleCmd.Parameters.Add (new OleDbParameter ("NorthLat", inBounds.TopLine));
			oleCmd.Parameters.Add (new OleDbParameter ("WestLong", inBounds.LeftLine));
			oleCmd.Parameters.Add (new OleDbParameter ("EastLong", inBounds.RightLine));
			oleConn.Open ();
			
			try
			{
				oleReader = oleCmd.ExecuteReader ();

				while (oleReader.Read ())
				{
					LocationInRadius loc = new LocationInRadius ();

					loc.City = Convert.ToString (oleReader["CITY"]);
					loc.State = Convert.ToString (oleReader["STATE"]);
					loc.ZipCode = Convert.ToString (oleReader["ZIP"]);
					loc.County = Convert.ToString (oleReader["COUNTY"]);
					loc.Latitude = Double.Parse (Convert.ToString (oleReader["LATITUDE"]));
					loc.Longitude = Double.Parse (Convert.ToString (oleReader["LONGITUDE"]));
					loc.ZipClass = Convert.ToString (oleReader["ZIP_CLASS"]);
					loc.DistanceToCenter = Distance.GetDistance (inRefLoc, loc);

					if (loc.DistanceToCenter <= inBounds.Radius)
						locs.Add (loc);
				}
			}
			catch (Exception e)
			{
				throw new ApplicationException ("Error getting data from database", e);
			}
			finally
			{
				if (null != oleReader)
					oleReader.Close ();
				if (null != oleConn)
					oleConn.Close ();
				locs.Sort (new LocationInRadiusComparer ());
			}

			return (LocationInRadius[]) locs.ToArray (typeof (LocationInRadius));
		}

		#endregion


		/// <summary>
		/// Allows for sorting of an ArrayList of <see cref="SagaraSoftware.ZipCodeUtil.LocationInRadius" /> 
		///  objects by DistanceToCenter, ascending.
		/// </summary>
		private class LocationInRadiusComparer : IComparer
		{
			public int Compare (object x, object y)
			{
				LocationInRadius lx = (LocationInRadius) x;
				LocationInRadius ly = (LocationInRadius) y;

				if (lx.DistanceToCenter < ly.DistanceToCenter)
					return -1;
				else if (lx.DistanceToCenter > ly.DistanceToCenter)
					return 1;
				else
					return 0;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// AccessProvider implements the IDataProvider interface, interacting with an MS Access 
	/// database.
	/// </summary>
	public class AccessProvider : IDataProvider
	{
		private string ConnectionString
		{
			get
			{
				string connStr = ConfigurationManager.AppSettings["ZipCodeConnString"];

				if (string.IsNullOrWhiteSpace(connStr))
					throw new Exception("You must provide a connection string for your MS Access database.");

				return connStr;
			}
		}


		//
		// IDataProvider Members
		//

		/// <summary>
		/// Look up a <see cref="SagaraSoftware.ZipCodeUtil.Location" /> by ZIP Code.  If Latitude
		///  or Longitude are NULL, they are set to double.MinValue.
		/// </summary>
		/// <param name="inZipCode">ZIP Code to lookup.</param>
		/// <returns><see cref="SagaraSoftware.ZipCodeUtil.Location" /> of the ZIP Code.</returns>
		public Location DoLookupByZipCode(string inZipCode)
		{
			Location loc = null;
			string sql = "SELECT * FROM ZIP_CODES WHERE ZIP = ?";

			using (var oleConn = new OleDbConnection(ConnectionString))
			using (var oleCmd = new OleDbCommand(sql, oleConn))
			{
				oleCmd.Parameters.Add(new OleDbParameter("ZIP", inZipCode));
				oleConn.Open();

				using (var oleReader = oleCmd.ExecuteReader())
				{
					if (oleReader.Read())
					{
						loc = ReadLocation<Location>(oleReader);
					}
				}
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
		public IList<Location> DoLookupByCityState(string inCity, string inState)
		{
			IList<Location> locs = new List<Location>();
			StringBuilder sql = new StringBuilder();

			sql.Append("SELECT * FROM ZIP_CODES WHERE CITY = ? AND STATE = ? ORDER BY ZIP");

			using (var oleConn = new OleDbConnection(ConnectionString))
			using (var oleCmd = new OleDbCommand(sql.ToString(), oleConn))
			{
				oleCmd.Parameters.Add(new OleDbParameter("CITY", inCity));
				oleCmd.Parameters.Add(new OleDbParameter("STATE", inState));
				oleConn.Open();

				using (var oleReader = oleCmd.ExecuteReader())
				{
					while (oleReader.Read())
					{
						locs.Add(ReadLocation<Location>(oleReader));
					}
				}
			}

			return locs;
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
		public IList<LocationInRadius> GetLocationsWithinRadius(Location inRefLoc, RadiusBox inBounds)
		{
			IList<LocationInRadius> locs = new List<LocationInRadius>();
			StringBuilder sql = new StringBuilder();

			sql.Append("SELECT * FROM ZIP_CODES WHERE ");
			sql.Append("IIf(ISNULL(LATITUDE),999.0,CDbl(LATITUDE)) >= ? AND ");
			sql.Append("IIf(ISNULL(LATITUDE),999.0,CDbl(LATITUDE)) <= ? AND ");
			sql.Append("IIf(ISNULL(LONGITUDE),999.0,CDbl(LONGITUDE)) >= ? AND ");
			sql.Append("IIf(ISNULL(LONGITUDE),999.0,CDbl(LONGITUDE)) <= ? ");
			sql.Append("ORDER BY CITY, STATE, ZIP");

			using (var oleConn = new OleDbConnection(ConnectionString))
			using (var oleCmd = new OleDbCommand(sql.ToString(), oleConn))
			{
				oleCmd.Parameters.Add(new OleDbParameter("SouthLat", inBounds.BottomLine));
				oleCmd.Parameters.Add(new OleDbParameter("NorthLat", inBounds.TopLine));
				oleCmd.Parameters.Add(new OleDbParameter("WestLong", inBounds.LeftLine));
				oleCmd.Parameters.Add(new OleDbParameter("EastLong", inBounds.RightLine));
				oleConn.Open();

				using (var oleReader = oleCmd.ExecuteReader())
				{
					LocationInRadius loc = null;

					while (oleReader.Read())
					{
						loc = ReadLocation<LocationInRadius>(oleReader);
						loc.DistanceToCenter = Distance.GetDistance(inRefLoc, loc);

						if (loc.DistanceToCenter <= inBounds.Radius)
						{
							locs.Add(loc);
						}
					}
				}
			}

			return locs
				.OrderBy(loc => loc.DistanceToCenter)
				.ToList();
		}


		//
		// Helpers
		//

		private T ReadLocation<T>(OleDbDataReader reader)
			where T : Location, new()
		{
			var loc = new T();

			loc.City = Convert.ToString(reader["CITY"]);
			loc.State = Convert.ToString(reader["STATE"]);
			loc.ZipCode = Convert.ToString(reader["ZIP"]);
			loc.County = Convert.ToString(reader["COUNTY"]);
			loc.Latitude = (reader["LATITUDE"] == DBNull.Value) ? double.MinValue : double.Parse(Convert.ToString(reader["LATITUDE"]));
			loc.Longitude = (reader["LONGITUDE"] == DBNull.Value) ? double.MinValue : double.Parse(Convert.ToString(reader["LONGITUDE"]));
			loc.ZipClass = Convert.ToString(reader["ZIP_CLASS"]);

			return loc;
		}
	}
}

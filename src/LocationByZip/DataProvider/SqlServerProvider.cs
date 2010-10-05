using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace LocationByZip.DataProvider
{
	/// <summary>
	/// Implements the IDataProvider interface, interacting with an SQL Server 2005+ database.
	/// </summary>
	public class SqlServerProvider : IDataProvider
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
		/// Look up a <see cref="LocationByZip.Location" /> by ZIP Code.  If Latitude
		///  or Longitude are NULL, they are set to double.MinValue.
		/// </summary>
		/// <param name="zipCode">ZIP Code to lookup.</param>
		/// <returns><see cref="LocationByZip.Location" /> of the ZIP Code.</returns>
		public Location DoLookupByZipCode(string zipCode)
		{
			Location loc = null;

			using (var conn = new SqlConnection(ConnectionString))
			using (var cmd = new SqlCommand(GetDoLookupByZipCodeSql(), conn))
			{
				cmd.Parameters.Add(new SqlParameter("@ZipCode", zipCode));
				conn.Open();

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						loc = ReadLocation<Location>(reader);
					}
				}
			}

			return loc;
		}

		/// <summary>
		/// Lookup one or more <see cref="LocationByZip.Location" />s by City/State.
		///  In the database, some cities are represented by more than one ZIP Code.
		/// </summary>
		/// <param name="city">Name of the City.</param>
		/// <param name="state">Name of the State.</param>
		/// <returns>An array of <see cref="LocationByZip.Location" /> objects whose City/State matches the input City/State.</returns>
		public IList<Location> DoLookupByCityState(string city, string state)
		{
			IList<Location> locs = new List<Location>();

			using (var conn = new SqlConnection(ConnectionString))
			using (var cmd = new SqlCommand(GetDoLookupByCityStateSql(), conn))
			{
				cmd.Parameters.Add(new SqlParameter("@City", city));
				cmd.Parameters.Add(new SqlParameter("@State", state));
				conn.Open();

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						locs.Add(ReadLocation<Location>(reader));
					}
				}
			}

			return locs;
		}

		/// <summary>
		/// Finds all <see cref="LocationByZip.LocationInRadius" />es within X miles
		///  of inRefLoc.
		/// </summary>
		/// <remarks>
		/// To speed the calculation, this method finds all areas within a square area of dimension
		///  (2*Radius)x(2*Radius).  Any city with a Lat/Lon pair that falls within this square is
		///  returned.  However, only those cities whose distance is less than or equal to Radius
		///  miles from inRefLoc are returned.  This has the unfortunate side effect of selecting
		///  from ~22% more area than is necessary.
		/// </remarks>
		/// <param name="pointOfReference">The central location from which we are trying to find other locations within the specified radius.</param>
		/// <param name="bounds">A class containing the "box" that encloses inRefLoc.  Used to approximate a circle of Radius R centered around the point inRefLoc.</param>
		/// <returns>0 or more <see cref="LocationByZip.LocationInRadius" />es that are
		///  within Radius miles of inRefLoc.</returns>
		public IList<LocationInRadius> GetLocationsWithinRadius(Location pointOfReference, RadiusBox bounds)
		{
			IList<LocationInRadius> locs = new List<LocationInRadius>();

			using (var conn = new SqlConnection(ConnectionString))
			using (var cmd = new SqlCommand(GetLocationsWithinRadiusSql(), conn))
			{
				cmd.Parameters.Add(new SqlParameter("@SouthLat", bounds.BottomLine));
				cmd.Parameters.Add(new SqlParameter("@NorthLat", bounds.TopLine));
				cmd.Parameters.Add(new SqlParameter("@WestLon", bounds.LeftLine));
				cmd.Parameters.Add(new SqlParameter("@EastLon", bounds.RightLine));
				conn.Open();

				using (var reader = cmd.ExecuteReader())
				{
					LocationInRadius loc = null;

					while (reader.Read())
					{
						loc = ReadLocation<LocationInRadius>(reader);
						loc.DistanceToCenter = Distance.GetDistance(pointOfReference, loc);

						if (loc.DistanceToCenter <= bounds.Radius)
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

		private string GetDoLookupByZipCodeSql()
		{
			return
@"SELECT
	  ZipCode
	, Latitude
	, Longitude
	, City
	, [State]
	, County
	, ZipClass
FROM
	ZipCode
WHERE
	ZipCode = @ZipCode";
		}

		private string GetDoLookupByCityStateSql()
		{
			return
@"SELECT
	  ZipCode
	, Latitude
	, Longitude
	, City
	, [State]
	, County
	, ZipClass
FROM
	ZipCode
WHERE 
	City = @City 
	AND [State] = @State 
ORDER BY 
	ZipCode";
		}

		private string GetLocationsWithinRadiusSql()
		{
			return
@"SELECT
	  ZipCode
	, Latitude
	, Longitude
	, City
	, [State]
	, County
	, ZipClass
FROM
	ZipCode
WHERE
	COALESCE(Latitude, 999.0) >= @SouthLat
	AND COALESCE(Latitude, 999.0) <= @NorthLat
	AND COALESCE(Longitude, 999.0) >= @WestLon
	AND COALESCE(Longitude, 999.0) <= @EastLon
ORDER BY
	  City
	, [State]
	, ZipCode";
		}

		private T ReadLocation<T>(SqlDataReader reader)
			where T : Location, new()
		{
			var loc = new T();

			loc.City = Convert.ToString(reader["City"]);
			loc.State = Convert.ToString(reader["State"]);
			loc.ZipCode = Convert.ToString(reader["ZipCode"]);
			loc.County = Convert.ToString(reader["County"]);
			loc.Latitude = (reader["Latitude"] == DBNull.Value) ? double.MinValue : Convert.ToDouble(reader["Latitude"]);
			loc.Longitude = (reader["Longitude"] == DBNull.Value) ? double.MinValue : Convert.ToDouble(reader["Longitude"]);
			loc.ZipClass = Convert.ToString(reader["ZipClass"]);

			return loc;
		}
	}
}

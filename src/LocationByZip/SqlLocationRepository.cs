using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LocationByZip
{
    public class SqlLocationRepository : ILocationRepository
    {
        private string _connectionString { get; }

        public SqlLocationRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("LocationByZip");
        }


        /// <summary>
        /// Look up a <see cref="Location" /> by ZIP Code.
        /// </summary>
        /// <param name="zipCode">ZIP Code to lookup.</param>
        /// <returns><see cref="Location" /> of the ZIP Code.</returns>
        public async Task<Location?> GetByZipCodeAsync(string zipCode)
        {
            using var conn = new SqlConnection(_connectionString);

            return (await conn.QueryAsync<Location>(GetDoLookupByZipCodeSql(), new { Zip5 = zipCode }))
                .SingleOrDefault();
        }

        /// <summary>
        /// Lookup one or more <see cref="Location" />s by City/State. In the database, some cities 
        /// are represented by more than one ZIP Code.
        /// </summary>
        /// <param name="city">Name of the City.</param>
        /// <param name="state">Name of the State.</param>
        /// <returns>An array of <see cref="Location" /> objects whose City/State matches the input City/State.</returns>
        public async Task<IReadOnlyCollection<Location>> GetByCityStateAsync(string city, string state)
        {
            using var conn = new SqlConnection(_connectionString);

            return (await conn.QueryAsync<Location>(GetDoLookupByCityStateSql(), new { city, state }))
                .ToArray();
        }

        /// <summary>
        /// Finds all <see cref="LocationInRadius" />es within X miles of <paramref name="origin"/>.
        /// </summary>
        /// <remarks>
        /// To speed the calculation, this method finds all areas within a square area of dimension (2*Radius)x(2*Radius). 
        /// Any city with a Lat/Lon pair that falls within this square is returned. However, only those cities whose 
        /// distance is less than or equal to Radius miles from inRefLoc are returned. This has the unfortunate side effect 
        /// of selecting from ~22% more area than is necessary.
        /// </remarks>
        /// <param name="origin">The central location from which we are trying to find other locations within the specified radius.</param>
        /// <param name="bounds">A class containing the "box" that encloses inRefLoc.  Used to approximate a circle of Radius R centered around the point inRefLoc.</param>
        /// <returns>0 or more <see cref="LocationInRadius" />es that are
        ///  within Radius miles of inRefLoc.</returns>
        public async Task<IReadOnlyCollection<LocationInRadius>> GetLocationsInRadiusAsync(Location origin, RadiusBox bounds)
        {
            var locationsInBoundingBox = new List<LocationInRadius>();

            using (var conn = new SqlConnection(_connectionString))
            {
                var args = new
                {
                    SouthLat = bounds.BottomLatitude,
                    NorthLat = bounds.TopLatitude,
                    WestLon = bounds.LeftLongitude,
                    EastLon = bounds.RightLongitude,
                };

                locationsInBoundingBox.AddRange(await conn.QueryAsync<LocationInRadius>(GetLocationsWithinRadiusSql(), args));
            }

            return locationsInBoundingBox
                // Compute the distance in miles from the origin (center of the circle).
                .Select(l =>
                {
                    l.DistanceToCenter = l.DistanceFrom(origin);
                    return l;
                })
                // Only keep those locations that are actually within the radius.
                .Where(l => l.DistanceToCenter <= bounds.RadiusMiles)
                // Put the closest to the origin first.
                .OrderBy(l => l.DistanceToCenter)
                .ToArray();
        }


        //
        // Helpers
        //

        private string GetDoLookupByZipCodeSql()
        {
            return
@"
SELECT
	  Zip5
	, PlaceName
	, AdminName1
	, AdminCode1
	, AdminName2
	, AdminCode2
	, AdminName3
	, AdminCode3
	, Latitude
	, Longitude
	, Accuracy
FROM
	ZipCodes
WHERE
	Zip5 = @Zip5
";
        }

        private string GetDoLookupByCityStateSql()
        {
            return
@"
SELECT
	  Zip5
	, PlaceName
	, AdminName1
	, AdminCode1
	, AdminName2
	, AdminCode2
	, AdminName3
	, AdminCode3
	, Latitude
	, Longitude
	, Accuracy
FROM
	ZipCodes
WHERE 
	PlaceName = @City 
	AND AdminCode1 = @State 
ORDER BY 
	Zip5
";
        }

        private string GetLocationsWithinRadiusSql()
        {
            return
@"
SELECT
	  Zip5
	, PlaceName
	, AdminName1
	, AdminCode1
	, AdminName2
	, AdminCode2
	, AdminName3
	, AdminCode3
	, Latitude
	, Longitude
	, Accuracy
FROM
	ZipCodes
WHERE
	Latitude >= @SouthLat
	AND Latitude <= @NorthLat
	AND Longitude >= @WestLon
	AND Longitude <= @EastLon
ORDER BY
	  PlaceName
	, AdminCode1
	, Zip5";
        }
    }
}

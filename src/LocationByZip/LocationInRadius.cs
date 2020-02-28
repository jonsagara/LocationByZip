using System.Text;

namespace LocationByZip
{
    public class LocationInRadius : Location
    {
        public double DistanceToCenter { get; set; }

        // Parameterless required for Dapper.
        public LocationInRadius()
        {
        }

        public LocationInRadius(string zip5, string placeName, string? adminName1, string? adminCode1, string? adminName2, string? adminCode2,
            string? adminName3, string? adminCode3, double latitude, double longitude, int accuracy, double distanceToCenter)
            : base(
                  zip5: zip5,
                  placeName: placeName,
                  adminName1: adminName1,
                  adminCode1: adminCode1,
                  adminName2: adminName2,
                  adminCode2: adminCode2,
                  adminName3: adminName3,
                  adminCode3: adminCode3,
                  latitude: latitude,
                  longitude: longitude,
                  accuracy: accuracy
                  )
        {
            DistanceToCenter = distanceToCenter;
        }

        public override string ToString()
        {
            var str = new StringBuilder(base.ToString());

            str.AppendLine($"\tDistance to original location: {DistanceToCenter:F1} miles");

            return str.ToString();
        }
    }
}

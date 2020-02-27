﻿using System.Text;

#nullable enable

namespace LocationByZip
{
    public class LocationInRadius : Location
    {
        public double DistanceToCenter { get; set; }

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
            var str = new StringBuilder();

            str.AppendLine($"Location: {PlaceName}, {AdminName1} {Zip5} in {AdminName2} County");
            str.AppendLine($"\tLatitude:\t{Latitude}");
            str.AppendLine($"\tLongitude:\t{Longitude}");
            str.AppendLine($"\tZip Class:\t{Zip5}");
            str.Append($"\tDistance to original location:\t{DistanceToCenter:F1} miles");

            return str.ToString();
        }
    }
}

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LocationByZip
{
    /// <summary>
    /// <para>A Location is represented by a 5-digit US ZIP Code, and has latitude/longitude coordinates. Most
    /// also have descriptive names about the jurisdiction.</para>
    /// <para>This just so happens to correspond to the columns of the ZipCodes table.</para>
    /// </summary>
    public class Location : IEquatable<Location>
    {
        public string Zip5 { get; set; }
        public string PlaceName { get; set; }
        public string? AdminName1 { get; set; }
        public string? AdminCode1 { get; set; }
        public string? AdminName2 { get; set; }
        public string? AdminCode2 { get; set; }
        public string? AdminName3 { get; set; }
        public string? AdminCode3 { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Accuracy { get; set; }

        // Justification: Need parameterless for Dapper.
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public Location()
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        {
        }

        public Location(string zip5, string placeName, string? adminName1, string? adminCode1, string? adminName2, string? adminCode2,
            string? adminName3, string? adminCode3, double latitude, double longitude, int accuracy)
        {
            if (string.IsNullOrWhiteSpace(zip5))
            {
                throw new ArgumentException($"{nameof(zip5)} can not be null or white space", nameof(zip5));
            }

            Zip5 = zip5;

            PlaceName = placeName;
            AdminName1 = adminName1;
            AdminCode1 = adminCode1;
            AdminName2 = adminName2;
            AdminCode2 = adminCode2;
            AdminName3 = adminName3;
            AdminCode3 = adminCode3;

            Latitude = latitude;
            Longitude = longitude;
            Accuracy = accuracy;
        }


        //
        // Instance Methods
        //

        public double DistanceFrom(Location remoteLocation)
        {
            VerifyLocation(remoteLocation);

            return Haversine.CalculateDistance(this, remoteLocation);
        }


        public override string ToString()
        {
            var str = new StringBuilder();

            str.AppendLine($"Location: {PlaceName}, {AdminName1} {Zip5} in {AdminName2} County");
            str.AppendLine($"\tLatitude:\t{Latitude}");
            str.AppendLine($"\tLongitude:\t{Longitude}");
            str.AppendLine($"\tAccuracy:\t{Accuracy}");

            return str.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Location);
        }

        public bool Equals([AllowNull] Location other)
        {
            // "x is object": https://twitter.com/jaredpar/status/1171477684523651072
            return (other is object) &&
                Zip5 == other.Zip5;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Zip5);
        }


        //
        // Private methods
        //

        private void VerifyLocation(Location? location)
        {
            if (location is null)
            {
                throw new ArgumentNullException(nameof(location));
            }
        }
    }
}

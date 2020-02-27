using System.Text;

namespace LocationByZip
{
    public class LocationInRadius : Location
    {
        public double DistanceToCenter { get; set; }

        public override string ToString()
        {
            var str = new StringBuilder();

            str.AppendLine($"Location: {City}, {State} {ZipCode} in {County} County");
            str.AppendLine($"\tLatitude:\t{Latitude}");
            str.AppendLine($"\tLongitude:\t{Longitude}");
            str.AppendLine($"\tZip Class:\t{ZipClass}");
            str.Append($"\tDistance to original location:\t{DistanceToCenter:F1} miles");

            return str.ToString();
        }
    }
}

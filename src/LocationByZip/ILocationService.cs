using System.Collections.Generic;

namespace LocationByZip
{
    public interface ILocationService
    {
        Location GetByZipCode(string zipCode);
        IEnumerable<Location> GetByCityState(string city, string state);
        IEnumerable<LocationInRadius> GetLocationsInRadius(string zipCode, double radius);
        double GetDistanceBetweenLocations(string zipCode1, string zipCode2);
    }
}

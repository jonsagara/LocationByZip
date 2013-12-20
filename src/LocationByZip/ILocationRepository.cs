using System.Collections.Generic;

namespace LocationByZip
{
    public interface ILocationRepository
    {
        Location GetByZipCode(string zipCode);
        IEnumerable<Location> GetByCityState(string city, string state);
        IEnumerable<LocationInRadius> GetLocationsInRadius(Location origin, RadiusBox bounds);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationByZip
{
    public interface ILocationRepository
    {
        Task<Location?> GetByZipCodeAsync(string zipCode);
        Task<IReadOnlyCollection<Location>> GetByCityStateAsync(string city, string state);
        Task<IReadOnlyCollection<LocationInRadius>> GetLocationsInRadiusAsync(Location origin, RadiusBox bounds);
    }
}

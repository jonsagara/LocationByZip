using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace LocationByZip
{
    public interface ILocationRepository
    {
        Task<Location?> GetByZipCodeAsync([AllowNull] string zipCode);
        Task<IReadOnlyCollection<Location>> GetByCityStateAsync([AllowNull] string city, [AllowNull] string state);
        Task<IReadOnlyCollection<LocationInRadius>> GetLocationsInRadiusAsync(Location origin, RadiusBox bounds);
    }
}

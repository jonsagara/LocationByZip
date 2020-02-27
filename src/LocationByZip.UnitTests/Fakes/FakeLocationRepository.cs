using System;
using System.Collections.Generic;
using System.Linq;

namespace LocationByZip.UnitTests.Fakes
{
    public class FakeLocationRepository : ILocationRepository
    {
        private List<Location> _locations = new List<Location>();

        public FakeLocationRepository()
        {
            #region Sacramento, CA
            _locations.Add(new Location { ZipCode = "94203", Latitude = 38.380456, Longitude = -121.555406, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94204", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94205", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94206", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94207", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94208", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94209", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94211", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94229", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94230", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94232", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94234", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94235", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94236", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94237", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94239", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94240", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94243", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94244", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94245", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94246", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94247", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94248", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94249", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94250", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94252", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94253", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94254", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94256", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94257", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94258", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94259", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94261", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94262", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94263", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94267", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94268", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94269", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94271", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94273", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94274", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94277", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94278", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94279", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94280", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94282", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94283", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94284", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94285", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94286", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94287", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94288", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94289", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94290", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94291", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94293", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94294", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94295", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94296", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94297", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94298", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "94299", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95812", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95813", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95814", Latitude = 38.579055, Longitude = -121.480905, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95815", Latitude = 38.589505, Longitude = -121.448665, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95816", Latitude = 38.571505, Longitude = -121.467549, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95817", Latitude = 38.549232, Longitude = -121.452264, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95818", Latitude = 38.557255, Longitude = -121.495915, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95819", Latitude = 38.568305, Longitude = -121.440764, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95820", Latitude = 38.536606, Longitude = -121.446414, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95821", Latitude = 38.627204, Longitude = -121.437964, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95822", Latitude = 38.511356, Longitude = -121.497716, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95823", Latitude = 38.481354, Longitude = -121.442071, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95824", Latitude = 38.517256, Longitude = -121.440764, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95825", Latitude = 38.585804, Longitude = -121.402213, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95826", Latitude = 38.547639, Longitude = -121.385459, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95827", Latitude = 38.552752, Longitude = -121.322653, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95828", Latitude = 38.488446, Longitude = -121.423245, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95829", Latitude = 38.495328, Longitude = -121.321524, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95830", Latitude = 38.490022, Longitude = -121.256140, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95831", Latitude = 38.497863, Longitude = -121.531332, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95832", Latitude = 38.435014, Longitude = -121.497276, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95833", Latitude = 38.621802, Longitude = -121.514016, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95834", Latitude = 38.584193, Longitude = -121.523566, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95835", Latitude = 38.667783, Longitude = -121.526051, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95836", Latitude = 38.710901, Longitude = -121.522717, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95837", Latitude = 38.692855, Longitude = -121.603038, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95838", Latitude = 38.645103, Longitude = -121.440015, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95840", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "UNIQUE" });
            _locations.Add(new Location { ZipCode = "95841", Latitude = 38.665385, Longitude = -121.353862, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95842", Latitude = 38.692752, Longitude = -121.359009, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95851", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95852", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95853", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95857", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "UNIQUE" });
            _locations.Add(new Location { ZipCode = "95860", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95864", Latitude = 38.586554, Longitude = -121.379467, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95865", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95866", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "95867", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "UNIQUE" });
            _locations.Add(new Location { ZipCode = "95873", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "UNIQUE" });
            _locations.Add(new Location { ZipCode = "95887", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "UNIQUE" });
            _locations.Add(new Location { ZipCode = "95894", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "UNIQUE" });
            _locations.Add(new Location { ZipCode = "95899", Latitude = 38.377411, Longitude = -121.444429, City = "SACRAMENTO", State = "CA", ZipClass = "UNIQUE" });
            #endregion

            #region Lathrop, CA
            _locations.Add(new Location { ZipCode = "95330", Latitude = 37.811976, Longitude = -121.287362, City = "LATHROP", State = "CA", ZipClass = "STANDARD" });
            #endregion

            #region Ketchikan, AK
            _locations.Add(new Location { ZipCode = "99901", Latitude = 55.400674, Longitude = -131.674090, City = "KETCHIKAN", State = "AK", ZipClass = "STANDARD" });
            _locations.Add(new Location { ZipCode = "99950", Latitude = 55.542007, Longitude = -131.432682, City = "KETCHIKAN", State = "AK", ZipClass = "STANDARD" });
            #endregion
        }


        //
        // ILocationRepository Methods
        //

        public Location GetByZipCode(string zipCode)
        {
            return _locations
                .Where(loc => loc.ZipCode.Equals(zipCode, StringComparison.OrdinalIgnoreCase))
                .SingleOrDefault();
        }

        public IEnumerable<Location> GetByCityState(string city, string state)
        {
            return _locations
                .Where(loc => loc.City.Equals(city, StringComparison.OrdinalIgnoreCase) && loc.State.Equals(state, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<LocationInRadius> GetLocationsInRadius(Location origin, RadiusBox bounds)
        {
            return _locations
                .Where(loc =>
                    {
                        return loc.Latitude >= bounds.BottomLatitude
                            && loc.Latitude <= bounds.TopLatitude
                            && loc.Longitude >= bounds.LeftLongitude
                            && loc.Longitude <= bounds.RightLongitude;
                    })
                .Select(loc =>
                    {
                        return new LocationInRadius
                        {
                            ZipCode = loc.ZipCode,
                            Latitude = loc.Latitude,
                            Longitude = loc.Longitude,
                            City = loc.City,
                            State = loc.State,
                            County = loc.County,
                            ZipClass = loc.ZipClass,
                            DistanceToCenter = loc.DistanceFrom(origin)
                        };
                    });
        }
    }
}

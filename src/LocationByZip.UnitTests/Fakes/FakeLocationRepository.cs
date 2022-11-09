using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LocationByZip.UnitTests.Fakes;

public class FakeLocationRepository : ILocationRepository
{
    private readonly List<Location> _locations = new List<Location>();

    public FakeLocationRepository()
    {
        #region Sacramento, CA
        _locations.AddRange(new[]
        {
            new Location(zip5: "94203", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94204", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94205", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94206", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94207", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94208", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94209", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94211", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94229", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94230", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94232", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94234", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94235", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94236", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94237", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94239", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94240", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94244", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94245", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94247", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94248", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94249", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94250", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94252", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94254", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94256", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94257", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94258", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94259", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94261", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94262", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94263", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94267", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94268", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94269", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94271", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94273", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94274", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94277", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94278", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94279", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94280", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94282", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94283", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94284", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94285", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94286", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94287", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94288", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94289", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94290", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94291", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94293", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94294", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94295", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94296", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94297", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94298", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "94299", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.494400, accuracy: 4),
            new Location(zip5: "95811", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.576200, longitude: -121.488000, accuracy: 4),
            new Location(zip5: "95812", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.582200, longitude: -121.494300, accuracy: 4),
            new Location(zip5: "95813", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.602600, longitude: -121.447500, accuracy: 4),
            new Location(zip5: "95814", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.580400, longitude: -121.492200, accuracy: 4),
            new Location(zip5: "95815", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.609300, longitude: -121.444300, accuracy: 4),
            new Location(zip5: "95816", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.572800, longitude: -121.467500, accuracy: 4),
            new Location(zip5: "95817", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.549800, longitude: -121.458300, accuracy: 4),
            new Location(zip5: "95818", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.556800, longitude: -121.492900, accuracy: 4),
            new Location(zip5: "95819", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.568300, longitude: -121.436600, accuracy: 4),
            new Location(zip5: "95820", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.534700, longitude: -121.445100, accuracy: 4),
            new Location(zip5: "95821", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.623900, longitude: -121.383700, accuracy: 4),
            new Location(zip5: "95822", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.509100, longitude: -121.493500, accuracy: 4),
            new Location(zip5: "95823", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.479700, longitude: -121.443800, accuracy: 4),
            new Location(zip5: "95824", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.517800, longitude: -121.441900, accuracy: 4),
            new Location(zip5: "95825", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.589200, longitude: -121.405700, accuracy: 4),
            new Location(zip5: "95826", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.553900, longitude: -121.369300, accuracy: 4),
            new Location(zip5: "95827", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.566200, longitude: -121.328600, accuracy: 4),
            new Location(zip5: "95828", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.482600, longitude: -121.400600, accuracy: 4),
            new Location(zip5: "95829", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.468900, longitude: -121.344000, accuracy: 4),
            new Location(zip5: "95830", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.489600, longitude: -121.277200, accuracy: 4),
            new Location(zip5: "95831", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.496200, longitude: -121.529700, accuracy: 4),
            new Location(zip5: "95832", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.469500, longitude: -121.488300, accuracy: 4),
            new Location(zip5: "95833", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.615700, longitude: -121.505300, accuracy: 4),
            new Location(zip5: "95834", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.638300, longitude: -121.507200, accuracy: 4),
            new Location(zip5: "95835", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.662600, longitude: -121.483400, accuracy: 4),
            new Location(zip5: "95836", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.719800, longitude: -121.534300, accuracy: 4),
            new Location(zip5: "95837", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.681700, longitude: -121.603000, accuracy: 4),
            new Location(zip5: "95838", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.640600, longitude: -121.444000, accuracy: 4),
            new Location(zip5: "95840", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.493300, accuracy: 4),
            new Location(zip5: "95841", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.662700, longitude: -121.340600, accuracy: 4),
            new Location(zip5: "95842", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.686500, longitude: -121.349400, accuracy: 4),
            new Location(zip5: "95851", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.602600, longitude: -121.447500, accuracy: 4),
            new Location(zip5: "95852", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.602600, longitude: -121.447500, accuracy: 4),
            new Location(zip5: "95853", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.602600, longitude: -121.447500, accuracy: 4),
            new Location(zip5: "95860", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.610500, longitude: -121.379900, accuracy: 4),
            new Location(zip5: "95864", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.587800, longitude: -121.376900, accuracy: 4),
            new Location(zip5: "95865", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.596000, longitude: -121.397800, accuracy: 4),
            new Location(zip5: "95866", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.596000, longitude: -121.397800, accuracy: 4),
            new Location(zip5: "95867", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.493300, accuracy: 4),
            new Location(zip5: "95894", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.581600, longitude: -121.493300, accuracy: 4),
            new Location(zip5: "95899", placeName: "Sacramento", adminName1: "California", adminCode1: "CA", adminName2: "Sacramento", adminCode2: "067", adminName3: null, adminCode3: null, latitude: 38.538300, longitude: -121.554900, accuracy: 4),
        });
        #endregion

        #region Lathrop, CA
        _locations.Add(new Location(zip5: "95330", placeName: "Lathrop", adminName1: "California", adminCode1: "CA", adminName2: "San Joaquin", adminCode2: "077", adminName3: null, adminCode3: null, latitude: 37.820900, longitude: -121.282700, accuracy: 4));
        #endregion

        #region Ketchikan, AK
        _locations.AddRange(new[]
        {
            new Location(zip5: "99901", placeName: "Ketchikan", adminName1: "Alaska", adminCode1: "AK", adminName2: "Ketchikan Gateway", adminCode2: "130", adminName3: null, adminCode3: null, latitude: 55.372000, longitude: -131.683200, accuracy: 4),
            new Location(zip5: "99950", placeName: "Ketchikan", adminName1: "Alaska", adminCode1: "AK", adminName2: "Ketchikan Gateway", adminCode2: "130", adminName3: null, adminCode3: null, latitude: 55.342200, longitude: -131.647800, accuracy: 4),
        });
        #endregion
    }


    //
    // ILocationRepository Methods
    //

    public Task<Location?> GetByZipCodeAsync([AllowNull] string zipCode)
    {
        var location = _locations
            .Where(loc => loc.Zip5.Equals(zipCode, StringComparison.OrdinalIgnoreCase))
            .SingleOrDefault();

        return Task.FromResult<Location?>(location);
    }

    public Task<IReadOnlyCollection<Location>> GetByCityStateAsync([AllowNull] string city, [AllowNull] string state)
    {
        var locations = _locations
            .Where(loc => loc.PlaceName.Equals(city, StringComparison.OrdinalIgnoreCase) && loc.AdminCode1?.Equals(state, StringComparison.OrdinalIgnoreCase) == true)
            .ToArray();

        return Task.FromResult((IReadOnlyCollection<Location>)locations);
    }

    public Task<IReadOnlyCollection<LocationInRadius>> GetLocationsInRadiusAsync(Location origin, RadiusBox bounds)
    {
        var locations = _locations
            .Where(loc =>
                {
                    return loc.Latitude >= bounds.BottomLatitude
                        && loc.Latitude <= bounds.TopLatitude
                        && loc.Longitude >= bounds.LeftLongitude
                        && loc.Longitude <= bounds.RightLongitude;
                })
            .Select(loc =>
                {
                    return new LocationInRadius(
                        zip5: loc.Zip5,
                        placeName: loc.PlaceName,
                        adminName1: loc.AdminName1,
                        adminCode1: loc.AdminCode1,
                        adminName2: loc.AdminName2,
                        adminCode2: loc.AdminCode2,
                        adminName3: loc.AdminName3,
                        adminCode3: loc.AdminCode3,
                        latitude: loc.Latitude,
                        longitude: loc.Longitude,
                        accuracy: loc.Accuracy,
                        distanceToCenter: loc.DistanceFrom(origin)
                        );
                })
            .ToArray();

        return Task.FromResult((IReadOnlyCollection<LocationInRadius>)locations);
    }
}

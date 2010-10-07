using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LocationByZip.UnitTests.Fakes;
using Xunit;

namespace LocationByZip.UnitTests
{
	public class LocationTests
	{
		//
		// GetByZipCode
		//

		[Fact]
		public void GetByZipCode_ValidZipCode_ReturnsNonNullLocation()
		{
			// Arrange
			var locationService = new LocationService(new FakeLocationRepository());

			// Act
			Location sacto = locationService.GetByZipCode("95814");

			// Assert
			Assert.NotNull(sacto);
		}

		[Fact]
		public void GetByZipCode_InvalidZipCode_ReturnsNullLocation()
		{
			// Arrange
			var locationService = new LocationService(new FakeLocationRepository());

			// Act
			Location fantasyLand = locationService.GetByZipCode("xzy123");

			// Assert
			Assert.Null(fantasyLand);
		}

		[Fact]
		public void GetByZipCode_NullZipCode_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByZipCode(null));
			Assert.True(argEx.Message.StartsWith("ZIP Code must be"));
		}

		[Fact]
		public void GetByZipCode_EmptyZipCode_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByZipCode(string.Empty));
			Assert.True(argEx.Message.StartsWith("ZIP Code must be"));
		}

		[Fact]
		public void GetByZipCode_WhiteSpaceZipCode_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByZipCode("\t "));
			Assert.True(argEx.Message.StartsWith("ZIP Code must be"));
		}


		//
		// GetByCityState
		//

		[Fact]
		public void GetByCityState_ValidCityValidState_ReturnsNonEmptyList()
		{
			// Arrange
			var locationService = new LocationService(new FakeLocationRepository());

			// Act
			IEnumerable<Location> sactoLocations = locationService.GetByCityState("Sacramento", "CA");

			// Assert
			Assert.True(sactoLocations.Count() > 0);
		}

		[Fact]
		public void GetByCityState_InvalidCityValidState_ReturnsEmptyList()
		{
			// Arrange
			var locationService = new LocationService(new FakeLocationRepository());

			// Act
			IEnumerable<Location> nonsenseLocations = locationService.GetByCityState("xyz123abc4217", "CA");

			// Assert
			Assert.True(nonsenseLocations.Count() == 0);
		}

		[Fact]
		public void GetByCityState_ValidCityInvalidState_ReturnsEmptyList()
		{
			// Arrange
			var locationService = new LocationService(new FakeLocationRepository());

			// Act
			IEnumerable<Location> nonsenseLocations = locationService.GetByCityState("Sacramento", "BB");

			// Assert
			Assert.True(nonsenseLocations.Count() == 0);
		}

		[Fact]
		public void GetByCityState_InvalidCityInvalidState_ReturnsEmptyList()
		{
			// Arrange
			var locationService = new LocationService(new FakeLocationRepository());

			// Act
			IEnumerable<Location> nonsenseLocations = locationService.GetByCityState("$#@ASDFad", "ZZ");

			// Assert
			Assert.True(nonsenseLocations.Count() == 0);
		}

		[Fact]
		public void GetByCityState_NullCityValidState_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByCityState(null, "ZZ"));
			Assert.True(argEx.Message.StartsWith("City must be non-null"));
		}

		[Fact]
		public void GetByCityState_EmptyCityValidState_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByCityState(string.Empty, "ZZ"));
			Assert.True(argEx.Message.StartsWith("City must be non-null"));
		}

		[Fact]
		public void GetByCityState_WhiteSpaceCityValidState_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByCityState(" \t", "ZZ"));
			Assert.True(argEx.Message.StartsWith("City must be non-null"));
		}

		[Fact]
		public void GetByCityState_ValidCityNullState_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByCityState("San Luis Obispo", null));
			Assert.True(argEx.Message.StartsWith("State must be non-null"));
		}

		[Fact]
		public void GetByCityState_ValidCityEmptyState_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByCityState("San Luis Obispo", string.Empty));
			Assert.True(argEx.Message.StartsWith("State must be non-null"));
		}

		[Fact]
		public void GetByCityState_ValidCityWhiteSpaceState_ThrowsArgumentException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var argEx = Assert.Throws<ArgumentException>(() => locationService.GetByCityState("San Luis Obispo", "\t "));
			Assert.True(argEx.Message.StartsWith("State must be non-null"));
		}


		//
		// GetLocationsInRadius
		//

		[Fact]
		public void GetLocationsInRadius_ValidZipCodeValidRadiusExistingLocationsNearby_ReturnsNonEmptyList()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			IEnumerable<LocationInRadius> locationsNearby = locationService.GetLocationsInRadius("95814", 5.0);

			Assert.NotEqual(0, locationsNearby.Count());
		}

		[Fact]
		public void GetLocationsInRadius_InvalidZipCodeValidRadiusExistingLocationsNearby_ReturnsEmptyList()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			IEnumerable<LocationInRadius> locationsNearby = locationService.GetLocationsInRadius("-12345", 5.0);

			Assert.Equal(0, locationsNearby.Count());
		}

		[Fact]
		public void GetLocationsInRadius_ValidZipCode0RadiusExistingLocationsNearby_ThrowsArgumentOutOfRangeException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var ex = Assert.Throws<ArgumentOutOfRangeException>(() => locationService.GetLocationsInRadius("95814", 0.0));
			Assert.True(ex.Message.StartsWith("Radius must be greater than 0"));
		}

		[Fact]
		public void GetLocationsInRadius_ValidZipCodeNegativeRadiusExistingLocationsNearby_ThrowsArgumentOutOfRangeException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var ex = Assert.Throws<ArgumentOutOfRangeException>(() => locationService.GetLocationsInRadius("95814", -100.0));
			Assert.True(ex.Message.StartsWith("Radius must be greater than 0"));
		}

		[Fact]
		public void GetLocationsInRadius_ValidZipCodeValidRadiusNoExistingLocationsNearby_ReturnsEmptyList()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			// There should be nothing within one mile of this ZIP code (see FakeLocationRepository's constructor).
			IEnumerable<LocationInRadius> locationsNearby = locationService.GetLocationsInRadius("99950", 1.0);

			// The Location itself is returned.
			Assert.Equal(1, locationsNearby.Count());
		}

		[Fact]
		public void GetLocationsInRadius_InvalidZipCodeInvalidRadiusExistingLocationsNearby_ThrowsArgumentOutOfRangeException()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			var ex = Assert.Throws<ArgumentOutOfRangeException>(() => locationService.GetLocationsInRadius("abcdefkjkjkjkjk", -3.14159));
			Assert.True(ex.Message.StartsWith("Radius must be greater than 0"));
		}


		//
		// GetDistanceBetweenLocations
		//

		[Fact]
		public void GetDistanceBetweenLocations_ValidZip1ValidZip2_ReturnsDistanceGreaterThan0()
		{
			var locationService = new LocationService(new FakeLocationRepository());

			double distance = locationService.GetDistanceBetweenLocations("95814", "95330");

			Assert.True(distance > 0.0);
		}
	}
}

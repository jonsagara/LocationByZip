﻿using System;
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
	}
}

using System;
using System.Linq;
using System.Threading.Tasks;
using LocationByZip.UnitTests.Fakes;
using Xunit;

namespace LocationByZip.UnitTests;

public class LocationTests
{
    //
    // GetByZipCode
    //

    [Fact]
    public async Task GetByZipCode_ValidZipCode_ReturnsNonNullLocation()
    {
        // Arrange
        var locationService = new LocationService(new FakeLocationRepository());

        // Act
        var sacto = await locationService.GetByZipCodeAsync("95814");

        // Assert
        Assert.NotNull(sacto);
    }

    [Fact]
    public async Task GetByZipCode_InvalidZipCode_ReturnsNullLocation()
    {
        // Arrange
        var locationService = new LocationService(new FakeLocationRepository());

        // Act
        var fantasyLand = await locationService.GetByZipCodeAsync("xzy123");

        // Assert
        Assert.Null(fantasyLand);
    }

    [Fact]
    public async Task GetByZipCode_NullZipCode_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByZipCodeAsync(null));
        Assert.StartsWith("ZIP Code must be", argEx.Message);
    }

    [Fact]
    public async Task GetByZipCode_EmptyZipCode_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByZipCodeAsync(string.Empty));
        Assert.StartsWith("ZIP Code must be", argEx.Message);
    }

    [Fact]
    public async Task GetByZipCode_WhiteSpaceZipCode_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByZipCodeAsync("\t "));
        Assert.StartsWith("ZIP Code must be", argEx.Message);
    }


    //
    // GetByCityState
    //

    [Fact]
    public async Task GetByCityState_ValidCityValidState_ReturnsNonEmptyList()
    {
        // Arrange
        var locationService = new LocationService(new FakeLocationRepository());

        // Act
        var sactoLocations = await locationService.GetByCityStateAsync("Sacramento", "CA");

        // Assert
        Assert.NotEmpty(sactoLocations);
    }

    [Fact]
    public async Task GetByCityState_InvalidCityValidState_ReturnsEmptyList()
    {
        // Arrange
        var locationService = new LocationService(new FakeLocationRepository());

        // Act
        var nonsenseLocations = await locationService.GetByCityStateAsync("xyz123abc4217", "CA");

        // Assert
        Assert.Empty(nonsenseLocations);
    }

    [Fact]
    public async Task GetByCityState_ValidCityInvalidState_ReturnsEmptyList()
    {
        // Arrange
        var locationService = new LocationService(new FakeLocationRepository());

        // Act
        var nonsenseLocations = await locationService.GetByCityStateAsync("Sacramento", "BB");

        // Assert
        Assert.Empty(nonsenseLocations);
    }

    [Fact]
    public async Task GetByCityState_InvalidCityInvalidState_ReturnsEmptyList()
    {
        // Arrange
        var locationService = new LocationService(new FakeLocationRepository());

        // Act
        var nonsenseLocations = await locationService.GetByCityStateAsync("$#@ASDFad", "ZZ");

        // Assert
        Assert.Empty(nonsenseLocations);
    }

    [Fact]
    public async Task GetByCityState_NullCityValidState_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByCityStateAsync(null, "ZZ"));
        Assert.StartsWith("City must be non-null", argEx.Message);
    }

    [Fact]
    public async Task GetByCityState_EmptyCityValidState_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByCityStateAsync(string.Empty, "ZZ"));
        Assert.StartsWith("City must be non-null", argEx.Message);
    }

    [Fact]
    public async Task GetByCityState_WhiteSpaceCityValidState_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByCityStateAsync(" \t", "ZZ"));
        Assert.StartsWith("City must be non-null", argEx.Message);
    }

    [Fact]
    public async Task GetByCityState_ValidCityNullState_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByCityStateAsync("San Luis Obispo", null));
        Assert.StartsWith("State must be non-null", argEx.Message);
    }

    [Fact]
    public async Task GetByCityState_ValidCityEmptyState_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByCityStateAsync("San Luis Obispo", string.Empty));
        Assert.StartsWith("State must be non-null", argEx.Message);
    }

    [Fact]
    public async Task GetByCityState_ValidCityWhiteSpaceState_ThrowsArgumentException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var argEx = await Assert.ThrowsAsync<ArgumentException>(async () => await locationService.GetByCityStateAsync("San Luis Obispo", "\t "));
        Assert.StartsWith("State must be non-null", argEx.Message);
    }


    //
    // GetLocationsInRadius
    //

    [Fact]
    public async Task GetLocationsInRadius_ValidZipCodeValidRadiusExistingLocationsNearby_ReturnsNonEmptyList()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var locationsNearby = await locationService.GetLocationsInRadiusAsync("95814", 5.0);

        Assert.NotEmpty(locationsNearby);
    }

    [Fact]
    public async Task GetLocationsInRadius_InvalidZipCodeValidRadiusExistingLocationsNearby_ReturnsEmptyList()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var locationsNearby = await locationService.GetLocationsInRadiusAsync("-12345", 5.0);

        Assert.Empty(locationsNearby);
    }

    [Fact]
    public async Task GetLocationsInRadius_ValidZipCode0RadiusExistingLocationsNearby_ThrowsArgumentOutOfRangeException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await locationService.GetLocationsInRadiusAsync("95814", 0.0));
        Assert.StartsWith("Radius must be greater than 0", ex.Message);
    }

    [Fact]
    public async Task GetLocationsInRadius_ValidZipCodeNegativeRadiusExistingLocationsNearby_ThrowsArgumentOutOfRangeException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await locationService.GetLocationsInRadiusAsync("95814", -100.0));
        Assert.StartsWith("Radius must be greater than 0", ex.Message);
    }

    [Fact]
    public async Task GetLocationsInRadius_ValidZipCodeValidRadiusNoExistingLocationsNearby_ReturnsEmptyList()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        // There should be nothing within one mile of this ZIP code (see FakeLocationRepository's constructor).
        var locationsNearby = await locationService.GetLocationsInRadiusAsync("99950", 1.0);

        // The Location itself is returned.
        Assert.Single(locationsNearby);
    }

    [Fact]
    public async Task GetLocationsInRadius_InvalidZipCodeInvalidRadiusExistingLocationsNearby_ThrowsArgumentOutOfRangeException()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var ex = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await locationService.GetLocationsInRadiusAsync("abcdefkjkjkjkjk", -3.14159));
        Assert.StartsWith("Radius must be greater than 0", ex.Message);
    }


    //
    // GetDistanceBetweenLocations
    //

    [Fact]
    public async Task GetDistanceBetweenLocations_ValidZip1ValidZip2_ReturnsDistanceGreaterThan0()
    {
        var locationService = new LocationService(new FakeLocationRepository());

        var distance = await locationService.GetDistanceBetweenLocationsAsync("95814", "95330");

        Assert.True(distance > 0.0);
    }
}

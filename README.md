LocationByZip
=============

This library provides a small set of methods to work with U.S. ZIP Codes. With it, you can:

* Get locations that fall within a given radius (in miles) of a certain ZIP Code
* Get a City/State by ZIP Code
* Get a collection of one or more ZIP Codes by City/State
* Determine the distance (in miles) between two ZIP Codes

This project uses the [geonames](https://www.geonames.org) [US Postal Code](https://download.geonames.org/export/zip/) file under the 
Creative Commons Attribution 3.0 License.

Usage
-----

In `DemoConsoleApp`, you'll see a .NET Core Generic Host set up to inject `LocationService` and `SqlLocationRepository`. You can use
a similar setup in, e.g., an ASP.NET Core MVC application, although with a web application, you'd likely want to add them as scoped services.

```csharp
services.AddTransient<LocationService, LocationService>();
services.AddTransient<ILocationRepository, SqlLocationRepository>();
```

You can then get an injected instance of `LocationService`.

To find all Locations within a given radius:

```csharp
// IReadOnlyCollection<LocationInRadius>
var locationsInRadius = locationSvc.GetLocationsInRadius("93401", 10.0);
```

To look up a Location by ZIP Code:

```csharp
// Location
var location = locationSvc.GetByZipCode("93275");
```

To look up a collection of Locations by City/State:

```csharp
// IReadOnlyCollection<Location>
var locations = locationSvc.GetByCityState("Tulare", "CA");
```

To find the distance (currently in miles) between two ZIP Codes:

```csharp
// double
var distanceInMiles = locationSvc.GetDistanceBetweenLocations("93401", "93446");
```


Creating the ZipCodes table
--------------------------

In the `data` folder, you'll find a CSV dump of US Postal Codes from 2020-02-26. Before generating the CSV, I removed the following two 
duplicates so that I could use `Zip5` as the primary key:

```
Zip5 = '96860' AND PlaceName = 'FPO AA'
Zip5 = '96863' AND PlaceName = 'FPO AA'
```

Import the CSV into the database of your choice. This code uses [Dapper](https://github.com/StackExchange/Dapper) to access a table named
`ZipCodes` in a recent version of `SQL Server` .

You can find and edit the SQL in `SqlLocationRepository.cs` in the `LocationByZip` project.

The connection string is in `appsettings.json` in the `LocationByZip.DemoConsoleApp` project.


History
----------------

This is a code refresh of an article I wrote at The Code Project: [ZIP Code Utility](http://www.codeproject.com/Articles/9198/ZIP-Code-Utility)

* 2020-02-28: `4.0.0`: Converted to .NET Core 3.1.
* 2013-12-19: Converted repo from `hg` to `git`. Hosted on GitHub.
* 2010-10-13: `3.0.0`: Code modernization.
* 2005-01-02: Initial release on CodeProject.

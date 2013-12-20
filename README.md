LocationByZip
=============

This library provides a small set of methods to work with U.S. ZIP Codes. With it, you can:

* Retrieve a City/State by ZIP Code.
* Retrieve a collection of one or more ZIP Codes that correspond to a City/State
* Retrieve a collection of locations that fall within a given radius of a certain ZIP Code
* Determine the distance (in miles) between two ZIP Codes

This is a code refresh of an article I wrote at The Code Project: [ZIP Code Utility](http://www.codeproject.com/KB/cs/zipcodeutil.aspx)

Instead of an Access database (which is no longer available for download), this code assumes you are using a SQL Server 2005+ database server. From the [Downloads](http://bitbucket.org/jonsagara/locationbyzip/downloads) tab, you can download the SQL script that creates and populates the ZipCode table.

Usage
-----

To begin with, you instantiate an instance of the LocationService class:

```csharp
ILocationService locationSvc = new LocationService();
```

Using this instance, you can then call the various methods on the ILocationService interface.

To look up a Location by ZIP Code:

```csharp
Location location = locationSvc.GetByZipCode("93275");
```

To look up a collection of Locations by City/State:

```csharp
IEnumerable<Location> locs = locationSvc.GetByCityState("Tulare", "CA");
```

To find all Locations within a given radius:

```csharp
IEnumerable<LocationInRadius> locsInRadius = locationSvc.GetLocationsInRadius("93401", 10.0);
```

To find the distance (currently in miles) between two ZIP Codes:

```csharp
double distance = locationSvc.GetDistanceBetweenLocations("93401", "93446");
```

To see the results returned by these calls, create the ZipCode table in your SQL Server database, and then compile and run the LocationByZip.DemoConsoleApp project.

Creating the ZipCode table
--------------------------

This assumes that you are using SQL Server 2005 or above.

1. From the [Downloads](http://bitbucket.org/jonsagara/locationbyzip/downloads) tab, download ZipCode.7z.
2. Using [7-Zip](http://www.7-zip.org/) or your favorite decompressor, extract ZipCode.sql from ZipCode.7z.
3. In SQL Server Management Studio, create or select a database where you want the ZipCode table to live.
4. Open ZipCode.sql in a new query window, and ensure your database is selected.
5. Run ZipCode.sql

That's it!
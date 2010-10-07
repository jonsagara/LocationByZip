--SELECT * FROM ZipCode WHERE City = 'Sacramento' AND [State] = 'CA'

DECLARE   @ZipCode NCHAR(5)
		, @Latitude NUMERIC(9, 6)
		, @Longitude NUMERIC(9, 6)
		, @City NVARCHAR(35)
		, @State NCHAR(2)
		, @County NVARCHAR(25)
		, @ZipClass NVARCHAR(15)
		, @Code NVARCHAR(MAX)

DECLARE ZipTestCursor CURSOR FOR
SELECT
	  ZipCode
	, Latitude
	, Longitude
	, City
	, [State]
	, County
	, ZipClass
FROM
	ZipCode
WHERE
	City = 'Sacramento'
	AND [State] = 'CA'
ORDER BY
	ZipCode
	
OPEN ZipTestCursor
FETCH NEXT FROM ZipTestCursor INTO @ZipCode, @Latitude, @Longitude, @City, @State, @County, @ZipClass

WHILE @@FETCH_STATUS = 0 BEGIN
	SET @Code = N'Locations.Add(new Location { ZipCode = "' + @ZipCode + N'"'
				+ N', Latitude = ' + CONVERT(VARCHAR(20), @Latitude) 
				+ N', Longitude = ' + CONVERT(VARCHAR(20), @Longitude)
				+ N', City = "' + @City + N'"'
				+ N', State = "' + @State + N'"'
				+ N', ZipClass = "' + @ZipClass + N'"'
				+ N' });' + NCHAR(13) + NCHAR(10) 
	
	PRINT @Code
	
	FETCH NEXT FROM ZipTestCursor INTO @ZipCode, @Latitude, @Longitude, @City, @State, @County, @ZipClass	
END

CLOSE ZipTestCursor
DEALLOCATE ZipTestCursor

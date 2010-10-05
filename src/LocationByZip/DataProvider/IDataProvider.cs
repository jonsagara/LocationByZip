using System;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// Defines methods common to all data providers.  An instance of this interface is used to 
	///  interact with the ZIP Codes database.  
	/// </summary>
	public interface IDataProvider
	{
		Location DoLookupByZipCode(string inZipCode);
		Location[] DoLookupByCityState(string inCity, string inState);
		LocationInRadius[] GetLocationsWithinRadius(Location inRefLoc, RadiusBox inBounds);
	}


	/// <summary>
	/// The DataProvider class has only one static method that returns an instance of a class that
	/// defines the IDataProvider interface.  The type of instance returned is determined by the
	/// "ZipCodeProviderType" key in the component host's application config file.  Supported types
	/// are Access, MS SQL, and MySQL.
	/// </summary>
	public class DataProvider
	{
		public static IDataProvider GetDataProvider()
		{
			string strProviderType = System.Configuration.ConfigurationSettings.AppSettings["ZipCodeProviderType"];

			if (null == strProviderType || string.Empty == strProviderType)
				throw new ApplicationException("The host application must define the ZipCodeProviderType key in the config file.");

			switch (strProviderType.ToUpper())
			{
				case "ACCESS":
					return new AccessProvider();
				case "MSSQL":
					throw new NotImplementedException("SqlProvider is not yet implemented");
				case "MYSQL":
					throw new NotImplementedException("MySqlProvider is not yet implemented");
				default:
					throw new ApplicationException("Invalid database provider type specified in config file.");
			}
		}
	}
}

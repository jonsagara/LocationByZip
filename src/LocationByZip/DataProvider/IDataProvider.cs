using System;
using System.Collections.Generic;
using System.Configuration;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// Defines methods common to all data providers.  An instance of this interface is used to 
	///  interact with the ZIP Codes database.  
	/// </summary>
	public interface IDataProvider
	{
		Location DoLookupByZipCode(string zipCode);
		IList<Location> DoLookupByCityState(string city, string state);
		IList<LocationInRadius> GetLocationsWithinRadius(Location pointOfReference, RadiusBox bounds);
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
			string strProviderType = ConfigurationManager.AppSettings["ZipCodeProviderType"];

			if (string.IsNullOrWhiteSpace(strProviderType))
				throw new Exception("The host application must define the ZipCodeProviderType key in the config file.");

			IDataProvider dp = null;
			switch (strProviderType.ToUpper())
			{
				case "MSSQL":
					dp = new SqlServerProvider();
					break;

				default:
					throw new Exception("Invalid database provider type specified in config file.");
			}

			if (dp == null)
			{
				throw new Exception("Unabled to instantiate data provider " + strProviderType);
			}

			return dp;
		}
	}
}

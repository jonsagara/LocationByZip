using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace LocationByZip.DataProvider
{
	internal static class DataProviderFactory
	{
		public static IDataProvider Create()
		{
			string strProviderType = ConfigurationManager.AppSettings["ZipCodeProviderType"];

			if (string.IsNullOrWhiteSpace(strProviderType))
			{
				throw new Exception("The host application must define the ZipCodeProviderType key in the config file.");
			}

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

using System;
using System.Collections.Generic;
using System.Diagnostics;

using LocationByZip.DataProvider;

namespace LocationByZip
{
	/// <summary>
	/// The ZipCodeUtil class provides methods to lookup City/State by ZIP Code, or ZIP Code by 
	/// City/State.
	/// </summary>
	/// <remarks>
	/// <para>Note that when looking up a ZIP Code by City/State, it is quite possible that more 
	/// than one <see cref="LocationByZip.Location" /> will be returned.</para>
	/// <para>When looking up a City/State by ZIP Code, only one <see cref="LocationByZip.Location" /> 
	/// will be returned.  ZIP Code is the Primary Key in the database.</para>
	///	</remarks>
	public static class ZipCodeUtil
	{
		/// <summary>
		/// Queries the database for a City/State whose ZIP Code matches inZipCode.
		/// </summary>
		/// <param name="zipCode">The ZIP Code to search by.</param>
		/// <returns>If a matching ZIP Code was found in the database, a <see cref="LocationByZip.Location" />
		///  object containing information about that ZIP Code.  Otherwise, returns null.</returns>
		public static Location LookupByZipCode(string zipCode)
		{
			VerifyZipCode(zipCode);

			return DataProviderFactory.Create().DoLookupByZipCode(zipCode);
		}


		/// <summary>
		/// Looks up a City/State by City/State.  It is possible for more than one <see cref="LocationByZip.Location" />
		///  to be returned since there are City/State combos that contain more than one ZIP Code.
		/// </summary>
		/// <param name="city">The search city.</param>
		/// <param name="state">The search state.</param>
		/// <returns>If any matches were found, an array of <see cref="LocationByZip.Location" /> objects.  Otherwise, null.</returns>
		public static IList<Location> LookupByCityState(string city, string state)
		{
			VerifyCity(city);
			VerifyState(state);

			return DataProviderFactory.Create().DoLookupByCityState(city, state);
		}


		//
		// Helpers
		//

		private static void VerifyCity(string city)
		{
			Debug.Assert(city != null);
			Debug.Assert(city != string.Empty);

			if (string.IsNullOrWhiteSpace(city))
			{
				throw new ArgumentException("You must specify a City when calling this method.  Current value: " + (city ?? "(null)"));
			}
		}

		private static void VerifyState(string state)
		{
			Debug.Assert(state != null);
			Debug.Assert(state != string.Empty);

			if (string.IsNullOrWhiteSpace(state))
			{
				throw new ArgumentException("You must specify a State when calling this method.  Current value: " + (state ?? "(null)"));
			}
		}

		private static void VerifyZipCode(string zipCode)
		{
			Debug.Assert(zipCode != null);
			Debug.Assert(zipCode != string.Empty);

			if (string.IsNullOrWhiteSpace(zipCode))
			{
				throw new ArgumentException("You must specify a ZIP Code when calling this method.  Current value: " + (zipCode ?? "(null)"));
			}
		}
	}
}

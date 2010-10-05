using System;
using System.Diagnostics;
using System.Collections.Generic;

using ZipCodeDataProvider = LocationByZip.DataProvider.DataProvider;

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

			return ZipCodeDataProvider
				.GetDataProvider()
				.DoLookupByZipCode(zipCode);
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

			return ZipCodeDataProvider
				.GetDataProvider()
				.DoLookupByCityState(city, state);
		}


		/// <summary>
		/// Looks up a City/State by City/State/ZIP.  Note: this is the same as looking up a 
		/// location by ZIP Code alone.
		/// </summary>
		/// <param name="city">The search city.</param>
		/// <param name="state">The search state.</param>
		/// <param name="zipCode">The search ZIP Code.</param>
		/// <returns>If a match is found, then a <see cref="LocationByZip.Location" /> object.
		///  Otherwise, null.</returns>
		public static Location LookupByCityStateZip(string city, string state, string zipCode)
		{
			VerifyCity(city);
			VerifyState(state);
			VerifyZipCode(zipCode);

			Location loc = LookupByZipCode(zipCode);
			if (loc != null)
			{
				if (!city.Equals(loc.City, StringComparison.OrdinalIgnoreCase)
					|| !state.Equals(loc.State, StringComparison.OrdinalIgnoreCase))
				{
					throw new Exception(
						string.Format(
							"The input City/State ({0}/{1}) does not match the City/State ({2}/{3}) associated with ZIP Code {4}", 
							city,
							state,
							loc.City,
							loc.State,
							zipCode
							)
						);
				}
			}

			return loc;
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

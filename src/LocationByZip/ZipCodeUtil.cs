using System;
using System.Diagnostics;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// The ZipCodeUtil class provides methods to lookup City/State by ZIP Code, or ZIP Code by 
	/// City/State.
	/// </summary>
	/// <remarks>
	/// <para>Note that when looking up a ZIP Code by City/State, it is quite possible that more 
	/// than one <see cref="SagaraSoftware.ZipCodeUtil.Location" /> will be returned.</para>
	/// <para>When looking up a City/State by ZIP Code, only one <see cref="SagaraSoftware.ZipCodeUtil.Location" /> 
	/// will be returned.  ZIP Code is the Primary Key in the database.</para>
	///	</remarks>
	public class ZipCodeUtil
	{
		/// <summary>
		/// Queries the database for a City/State whose ZIP Code matches inZipCode.
		/// </summary>
		/// <param name="inZipCode">The ZIP Code to search by.</param>
		/// <returns>If a matching ZIP Code was found in the database, a <see cref="SagaraSoftware.ZipCodeUtil.Location" />
		///  object containing information about that ZIP Code.  Otherwise, returns null.</returns>
		public static Location LookupByZipCode(String inZipCode)
		{
			Debug.Assert(null != inZipCode);
			Debug.Assert(String.Empty != inZipCode);

			if (null == inZipCode)
				throw new ArgumentNullException("inZipCode");
			if (String.Empty == inZipCode)
				throw new ArgumentException("You must specify a ZIP Code when calling this method.", "inZipCode");

			Location loc = null;
			IDataProvider db = null;

			try
			{
				db = DataProvider.GetDataProvider();

				if (null != db)
					loc = db.DoLookupByZipCode(inZipCode);
			}
			catch (Exception e)
			{
				// JonJon: Need to implement logging.
				throw new ApplicationException("Rethrowing exception", e);
			}

			return loc;
		}


		/// <summary>
		/// Looks up a City/State by City/State.  It is possible for more than one <see cref="SagaraSoftware.ZipCodeUtil.Location" />
		///  to be returned since there are City/State combos that contain more than one ZIP Code.
		/// </summary>
		/// <param name="inCity">The search city.</param>
		/// <param name="inState">The search state.</param>
		/// <returns>If any matches were found, an array of <see cref="SagaraSoftware.ZipCodeUtil.Location" /> objects.  Otherwise, null.</returns>
		public static Location[] LookupByCityState(String inCity, String inState)
		{
			Debug.Assert(null != inCity);
			Debug.Assert(String.Empty != inCity);
			Debug.Assert(null != inState);
			Debug.Assert(String.Empty != inState);

			if (null == inCity)
				throw new ArgumentNullException("inCity");
			if (String.Empty == inCity)
				throw new ArgumentException("You must specify a City when calling this method.", "inCity");
			if (null == inState)
				throw new ArgumentNullException("inState");
			if (String.Empty == inState)
				throw new ArgumentException("You must specify a State when calling this method.", "inState");

			Location[] locs = null;
			IDataProvider db = null;

			try
			{
				db = DataProvider.GetDataProvider();

				if (null != db)
					locs = db.DoLookupByCityState(inCity, inState);
			}
			catch (Exception e)
			{
				// JonJon: Need to implement logging.
				throw new ApplicationException("Rethrowing exception", e);
			}

			return locs;
		}


		/// <summary>
		/// Looks up a City/State by City/State/ZIP.
		/// </summary>
		/// <param name="inCity">The search city.</param>
		/// <param name="inState">The search state.</param>
		/// <param name="inZipCode">The search ZIP Code.</param>
		/// <returns>If a match is found, then a <see cref="SagaraSoftware.ZipCodeUtil.Location" /> objectd.
		///  Otherwise, null.</returns>
		public static Location LookupByCityStateZip(String inCity, String inState, String inZipCode)
		{
			Debug.Assert(null != inCity);
			Debug.Assert(String.Empty != inCity);
			Debug.Assert(null != inState);
			Debug.Assert(String.Empty != inState);
			Debug.Assert(null != inZipCode);
			Debug.Assert(String.Empty != inZipCode);

			if (null == inCity)
				throw new ArgumentNullException("inCity");
			if (String.Empty == inCity)
				throw new ArgumentException("You must specify a City when calling this method.", "inCity");
			if (null == inState)
				throw new ArgumentNullException("inState");
			if (String.Empty == inState)
				throw new ArgumentException("You must specify a State when calling this method.", "inState");
			if (null == inZipCode)
				throw new ArgumentNullException("inZipCode");
			if (String.Empty == inZipCode)
				throw new ArgumentException("You must specify a ZIP Code when calling this method.", "inZipCode");

			Location loc = LookupByZipCode(inZipCode);
			if (null != loc)
			{
				if (inCity.ToUpper() != loc.City.ToUpper() || inState.ToUpper() != loc.State.ToUpper())
					throw new ApplicationException(string.Format("The City/State you specified does not match the City/State associated with ZIP Code {0}", inZipCode));
			}

			return loc;
		}
	}
}

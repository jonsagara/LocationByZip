﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationByZip
{
	public class LocationService : ILocationService
	{
		//
		// Instance Data
		//

		private ILocationRepository locationRepository;


		//
		// Instance Constructors
		//

		public LocationService(ILocationRepository locationRepository)
		{
			this.locationRepository = locationRepository;
		}


		//
		// ILocationService Methods
		//

		public Location GetByZipCode(string zipCode)
		{
			ValidateZipCodeArgument(zipCode);

			return locationRepository.GetByZipCode(zipCode);
		}

		public IEnumerable<Location> GetByCityState(string city, string state)
		{
			ValidateCityArgument(city);
			ValidateStateArgument(state);

			return locationRepository.GetByCityState(city, state);
		}


		//
		// Helpers
		//

		private void ValidateZipCodeArgument(string zipCode)
		{
			if (string.IsNullOrWhiteSpace(zipCode))
			{
				throw new ArgumentException("ZIP Code must be non-null, non-white space string", "zipCode");
			}
		}

		private void ValidateCityArgument(string city)
		{
			if (string.IsNullOrWhiteSpace(city))
			{
				throw new ArgumentException("City must be non-null, non-white space string", "city");
			}
		}

		private void ValidateStateArgument(string state)
		{
			if (string.IsNullOrWhiteSpace(state))
			{
				throw new ArgumentException("State must be non-null, non-white space string", "state");
			}
		}
	}
}

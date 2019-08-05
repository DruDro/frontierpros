using FrontierPros.Core.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Stores;
using Nop.Services.Catalog;
using Nop.Services.Events;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrontierPros.Services.Locations
{
	public class LocationService : ILocationService
	{
		#region Fields
		private readonly IRepository<Country> _countryRepository;
		private readonly IRepository<Region> _regionRepository;
		private readonly IRepository<City> _cityRepository;
		#endregion

		#region Ctor

		public LocationService(IRepository<Country> countryRepository, 
			IRepository<Region> regionRepository,
			IRepository<City> cityRepository)
		{
			this._countryRepository = countryRepository;
			this._regionRepository = regionRepository;
			this._cityRepository = cityRepository;
		}

		#endregion

		#region Methods
		public virtual IList<Country> GetAllCountries()
		{
			var query = _countryRepository.Table
				.OrderBy(c => c.Name);

			return query.ToArray();
		}

		public virtual IList<Region> GetAllRegionsByCountryId(int countryId)
		{
			var query = _regionRepository.Table
				.Where(r => r.CountryId == countryId)
				.OrderBy(r => r.Name);

			return query.ToArray();
		}

		public virtual IList<City> GetAllCities(int countryId, int regionId)
		{
			var query = _cityRepository.Table
				.Where(c => c.CountryId == countryId && c.RegionId == regionId)
				.OrderBy(c => c.Name);

			return query.ToArray();
		}

		public virtual IList<City> GetAllCitiesByCountryId(int countryId)
		{
			var query = _cityRepository.Table
				.Where(c => c.CountryId == countryId)
				.OrderBy(c => c.Name);

			return query.ToArray();
		}



		#endregion
	}
}

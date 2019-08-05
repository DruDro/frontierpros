using FrontierPros.Core.Domain.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.Locations
{
	public interface ILocationService
	{
		IList<Country> GetAllCountries();
		IList<Region> GetAllRegionsByCountryId(int countryId);

		IList<City> GetAllCitiesByCountryId(int countryId);
		IList<City> GetAllCities(int countryId, int regionId);
	}
}

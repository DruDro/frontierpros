using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.TimeZones;
using FrontierPros.Services.Locations;
using FrontierPros.Services.Providers;
using FrontierPros.Services.TimeZones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Data;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Web.Models.Profile;

namespace Nop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
		private readonly ILocationService _locationService;

        public CountriesController(ILocationService locationService)
        {
			this._locationService = locationService;
		}

        [HttpGet]
        public IActionResult GetAllCountries()
        {
			var countries = _locationService.GetAllCountries();

			var countryDtos = countries.Select(t => new
			{
				t.Id,
				t.Name
			}).ToList();

			return new JsonResult(countryDtos);
		}

		[HttpGet("{countryId}/regions")]
		public IActionResult GetAllRegionsByCountryId(int countryId)
		{
			var regions = _locationService.GetAllRegionsByCountryId(countryId);

			var regionDtos = regions.Select(t => new
			{
				t.Id,
				t.Name
			}).ToList();

			return new JsonResult(regionDtos);
		}

		[HttpGet("{countryId}/cities")]
		public IActionResult GetAllCitiesByCountryId(int countryId)
		{
			var cities = _locationService.GetAllCitiesByCountryId(countryId);

			var citiesDtos = cities.Select(t => new
			{
				t.Id,
				t.Name,
			}).ToList();

			return new JsonResult(citiesDtos);
		}

		[HttpGet("{countryId}/regions/{regionId}/cities")]
		public IActionResult GetAllCities(int countryId, int regionId)
		{
			var cities = _locationService.GetAllCities(countryId, regionId);

			var citiesDtos = cities.Select(t => new
			{
				t.Id,
				t.Name
			}).ToList();

			return new JsonResult(citiesDtos);
		}
	}
}
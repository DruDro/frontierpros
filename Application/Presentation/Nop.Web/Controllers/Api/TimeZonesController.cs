using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontierPros.Core.Domain.Customers;
using FrontierPros.Core.Domain.TimeZones;
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
    public class TimeZonesController : Controller
    {
		private readonly ITimeZoneDataService _timeZoneDataService;

        public TimeZonesController(ITimeZoneDataService timeZoneDataService)
        {
			this._timeZoneDataService = timeZoneDataService;
		}

        [HttpGet]
        public IActionResult Index()
        {
			var orderedTimeZones = _timeZoneDataService.GetAllTimeZoneDataEntities();
			var timeZoneDtos = orderedTimeZones.Select(t => new
			{
				t.Id,
				Text = _timeZoneDataService.GetTimeZoneText(t)
			}).ToList();

			return new JsonResult(timeZoneDtos);
		}
    }
}
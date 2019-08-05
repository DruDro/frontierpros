using FrontierPros.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Models.Services;
using System.Linq;

namespace Nop.Web.Controllers.Api
{
	[Route("api/service-items")]
    [ApiController]
    public class ServiceItemsController : ControllerBase
    {
		private readonly IServiceItemService _serviceItemService;

		public ServiceItemsController(IServiceItemService serviceInfoService)
		{
			this._serviceItemService = serviceInfoService;
		}

		[HttpGet("{id?}")]
		public IActionResult Index(int id)
		{
			var serviceItem = _serviceItemService.GetServiceItemById(id);

			if (serviceItem == null)
			{
				return new JsonResult(null);
			}

			var serviceItemDto = new
			{
				serviceItem.Id,
				serviceItem.Description,
			};

			return new JsonResult(serviceItemDto);
		}

		[HttpPost("search")]
		public IActionResult Index(ServiceItemFilterModel filter)
		{
			var serviceItems = _serviceItemService.GetAllServiceItems(filter.SearchTerm, 
																	filter.ServiceCategoryId, 
																	filter.ServiceInfoId,
																	filter.WorkLocationType, 
																	filter.Latitude, 
																	filter.Longitude,
																	filter.DistanceTravel, 
																	filter.PageIndex, 
																	filter.PageSize);

			var serviceItemDtos = serviceItems.Select(s => new {
				s.Id,
				s.Description,
				s.WorkLocationType
			}).ToArray();

			return new JsonResult(serviceItemDtos);
		}
	}
}